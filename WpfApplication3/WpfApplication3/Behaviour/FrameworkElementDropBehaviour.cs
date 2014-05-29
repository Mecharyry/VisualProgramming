using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using WpfApplication3.Common;
using WpfApplication3.Interfaces;

namespace WpfApplication3.Behaviour
{
    class FrameworkElementDropBehaviour : Behavior<FrameworkElement>
    {
        protected Type dataType;

        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.AllowDrop = true;
            this.AssociatedObject.DragEnter += new DragEventHandler(AssociatedObject_DragEnter);
            this.AssociatedObject.DragOver += new DragEventHandler(AssociatedObject_DragOver);
            this.AssociatedObject.Drop += new DragEventHandler(AssociatedObject_Drop);
        }

        protected virtual void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            if (dataType != null)
            {
                // If the data type can be dropped.
                if (e.Data.GetDataPresent(dataType))
                {
                    // Drop the data.
                    IDropable target = this.AssociatedObject.DataContext as IDropable;

                    // Retrieve the listbox display from the view.
                    ListBox parent = Helper.FindAnchestor<ListBox>(sender as DependencyObject);
                    if (parent != null)
                    {
                        Point currentPoint = e.GetPosition(parent);
                        target.Drop(e.Data.GetData(dataType), currentPoint.X, currentPoint.Y);
                    }
                    else
                    {
                        target.Drop(e.Data.GetData(dataType));
                    }
                }
            }
            e.Handled = true;
            return;
        }

        void AssociatedObject_DragOver(object sender, DragEventArgs e)
        {
            if (dataType != null)
            {
                // If the item can be dropped.
                if (e.Data.GetDataPresent(dataType))
                {
                    this.SetDragDropEffects(e);
                }
            }
            e.Handled = true;
        }

        void AssociatedObject_DragEnter(object sender, DragEventArgs e)
        {
            // If the DataContext implements IDropable, record the data type that can be dropped.
            if (this.dataType == null)
            {
                if (this.AssociatedObject.DataContext != null)
                {
                    IDropable dropObject = this.AssociatedObject.DataContext as IDropable;

                    if (dropObject != null)
                    {
                        this.dataType = dropObject.DataType;
                    }
                }
            }
            e.Handled = true;
        }

        private void SetDragDropEffects(DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            // If the data type can be dropped.
            if (e.Data.GetDataPresent(dataType))
            {
                e.Effects = DragDropEffects.Copy;
            }
        }
    }
}
