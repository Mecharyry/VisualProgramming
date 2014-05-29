/// The structure for this class was derived using the tutorial 
/// available at the code project website and the code therein
/// is available under the code project open licence.
/// Source: http://www.codeproject.com/Articles/87715/Native-WPF-PropertyGrid
using System;
using System.Activities.Presentation;
using System.Activities.Presentation.Model;
using System.Activities.Presentation.View;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApplication3.Common;

namespace WpfApplication3.PropertiesGrid
{
    public class PropertiesGrid : Grid
    {
        #region Class Fields
        public static readonly DependencyProperty SelectedObjectProperty =
            DependencyProperty.Register("SelectedObject", typeof(object), typeof(PropertiesGrid),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, SelectedObjectPropertyChanged));

        private WorkflowDesigner _designer;
        private MethodInfo _onSelectionChangedMethod;
        #endregion

        #region Class Properties
        public object SelectedObject
        {
            get { return GetValue(SelectedObjectProperty); }
            set { SetValue(SelectedObjectProperty, value); }
        }

        public WorkflowDesigner Designer
        {
            get { return _designer; }
            private set { _designer = value; }
        }

        public MethodInfo OnSelectionChangedMethod
        {
            get { return _onSelectionChangedMethod; }
            private set { _onSelectionChangedMethod = value; }
        }
        #endregion

        #region Constructor
        public PropertiesGrid()
        {
            Designer = new WorkflowDesigner();

            UIElement inspectorView = Designer.PropertyInspectorView;
            inspectorView.Visibility = Visibility.Visible;
            inspectorView.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Stretch);

            UIElement element = Designer.View;
            element.SetValue(Border.BorderThicknessProperty, new Thickness(0));

            this.Children.Add(inspectorView);

            Type inspectorType = inspectorView.GetType();
            this.OnSelectionChangedMethod = inspectorType.GetMethod("OnSelectionChanged",
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.NonPublic);

            Mediator.Instance.Register(
                (Object o) =>
                {
                    SelectedObject = o;
                }, Mediator.ViewModelMessages.PropertiesSelection);
        }
        #endregion

        #region Methods
        private static void SelectedObjectPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            PropertiesGrid propertiesGrid = source as PropertiesGrid;

            if (e.NewValue != null)
            {
                EditingContext context = new EditingContext();
                ModelTreeManager mtm = new ModelTreeManager(context);
                mtm.Load(e.NewValue);
                Selection selection = Selection.Select(context, mtm.Root);

                propertiesGrid.OnSelectionChangedMethod.Invoke(propertiesGrid.Designer.PropertyInspectorView, new object[] { selection });
            }
            else
            {
                propertiesGrid.OnSelectionChangedMethod.Invoke(propertiesGrid.Designer.PropertyInspectorView, new object[] { null });
            }
        }
        #endregion
    }
}
