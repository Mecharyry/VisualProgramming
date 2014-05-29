using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using WpfApplication3.Code_Generator;
using WpfApplication3.Common;
using WpfApplication3.Database;
using WpfApplication3.Interfaces;
using WpfApplication3.Model;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.View;

namespace WpfApplication3.ViewModel
{
    public class MainViewModel
    {
        #region Members
        private MainModel _currentMainModel;
        private ObservableCollection<DesignerViewModel> _designers = new ObservableCollection<DesignerViewModel>();
        private ObservableCollection<VariableModel> _variables = VariablesDB.Instance.GlobalVariables;
        #endregion

        #region Properties
        [XmlIgnore]
        public MainModel CurrentMainModel
        {
            get { return _currentMainModel; }
            set { _currentMainModel = value; }
        }

        public ObservableCollection<DesignerViewModel> Designers
        {
            get { return _designers; }
            set { _designers = value; }
        }
        #endregion

        #region Constructor
        public MainViewModel(string defaultTab) 
            : this()
        {
            _currentMainModel = new MainModel();
            Designers.Add(new DesignerViewModel(new DesignerModel() { DesignerName = defaultTab }));
        }

        public MainViewModel()
        {
            Mediator.Instance.Register(
                (Object o) =>
                {
                    AddTab(o as ControlViewModel);
                }, Mediator.ViewModelMessages.AddTab);

            Mediator.Instance.Register(
            (Object o) =>
            {
                RemoveTab(o as ControlViewModel);
            }, Mediator.ViewModelMessages.RemoveControl);
        }
        #endregion

        #region Methods
        public void AddTab(ControlViewModel control)
        {
            Designers.Add(new DesignerViewModel(new DesignerModel() 
            { 
                DesignerName = control.CurrentCodeModel.ControlName 
            }, control));
        }

        public void RemoveTab(ControlViewModel control)
        {
            for (int i = 0; i < Designers.Count; i++)
            {
                DesignerViewModel designer = Designers[i];
                if (designer.Parent != null && 
                    designer.Parent.Id == control.Id)
                {
                    designer.RemoveAllControls();
                    Designers.Remove(designer);
                    i = i - 1;
                }
            }
        }
        #endregion

        #region Commands
        public void GenerateCommandExecute()
        {
            // Use serialisation in order to save a copy of the current designer
            // and pass to the code generator.
            Helper.ObjectToXml(this, Constants.OutputDirectory + @"\xml.txt");
            object obj = Helper.XmlToObject(this.GetType(), Constants.OutputDirectory + @"\xml.txt");

            if (obj != null)
            {
                MainViewModel viewModel = obj as MainViewModel;
                ObservableCollection<DesignerViewModel> temp = viewModel.Designers as ObservableCollection<DesignerViewModel>;
                _variables = viewModel._variables as ObservableCollection<VariableModel>;

                List<VariableModel> variables = new List<VariableModel>();
                List<DesignerViewModel> designers = new List<DesignerViewModel>();
                for (int i = 0; i < temp.Count; i++)
                {
                    designers.Add(temp[i]);
                }
                for (int i = 0; i < VariablesDB.Instance.GlobalVariables.Count; i++)
                {
                    variables.Add(_variables[i]);
                }

                Mediator.Instance.Notify(Mediator.ViewModelMessages.PropertiesSelection, null);
                GeneratorManager.Instance.GenerateModel(designers, variables);
            }
            else
            {
                MessageBox.Show("Error with model, please try again.");
            }
        }

        private ICommand _generateCommand;
        public ICommand GenerateCommand
        {
            get
            {
                if (_generateCommand == null)
                {
                    _generateCommand = new Command(this.GenerateCommandExecute);
                }
                return _generateCommand;
            }
        }

        public void OpenCommandExecute()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".xml";
            open.Filter = "XML Documents (.xml)|*.xml";

            Nullable<bool> result = open.ShowDialog();

            if (result == true)
            {
                Object obj = Helper.XmlToObject(this.GetType(), open.FileName);
                MainViewModel viewModel = obj as MainViewModel;
                if (obj != null)
                {
                    ObservableCollection<DesignerViewModel> source = viewModel.Designers as ObservableCollection<DesignerViewModel>;

                    for (int i = Designers.Count - 1; i >= 0; i--)
                    {
                        Designers.RemoveAt(i);
                    }

                    // Add designers to collections.
                    for (int designerIndex = 0; designerIndex < source.Count; designerIndex++)
                    {
                        DesignerViewModel currentDesigner = source[designerIndex];

                        // Create a copy of the designer view model.
                        DesignerViewModel destinationDesigner = new DesignerViewModel(new DesignerModel() { DesignerName = currentDesigner.DesignerName }, currentDesigner.Parent);

                        // Add it to the designers collections.
                        Designers.Add(destinationDesigner);

                        // Add each of the controls.
                        for (int controlIndex = 0; controlIndex < currentDesigner.Controls.Count; controlIndex++)
                        {
                            destinationDesigner.Controls.Add(currentDesigner.Controls[controlIndex]);
                        }

                        // Determine whether start model is present.
                        ConnectionModel sourceConnection = currentDesigner.Connections.FirstOrDefault(x => x.Start.GetType() == typeof(StartModel));
                        if (sourceConnection != null)
                        {
                            destinationDesigner.StartConnection(destinationDesigner.StartControl[0]);
                            destinationDesigner.EndConnection(destinationDesigner.Controls.First(x => x.Id == sourceConnection.End.Id));

                            // Process the remaining connections; -1 start is already done.
                            for (int connectionIndex = 0; connectionIndex < currentDesigner.Connections.Count - 1; connectionIndex++)
                            {
                                sourceConnection = currentDesigner.Connections.First(x => x.Start.Id == sourceConnection.End.Id);

                                destinationDesigner.StartConnection(destinationDesigner.Controls.First(x => x.Id == sourceConnection.Start.Id));
                                destinationDesigner.EndConnection(destinationDesigner.Controls.First(x => x.Id == sourceConnection.End.Id));
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Xml file please try again.");
                }
            }
        }

        private ICommand _openCommand;
        public ICommand OpenCommand
        {
            get
            {
                if (_openCommand == null)
                {
                    _openCommand = new Command(this.OpenCommandExecute);
                }
                return _openCommand;
            }
        }

        public void SaveCommandExecute()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "CodeModel";
            save.DefaultExt = ".xml";
            save.Filter = "XML Documents (.xml)|*.xml";

            Nullable<bool> result = save.ShowDialog();

            if (result == true)
            {
                Helper.ObjectToXml(this, save.FileName);
            }
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new Command(this.SaveCommandExecute);
                }
                return _saveCommand;
            }
        }
        #endregion
    }
}
