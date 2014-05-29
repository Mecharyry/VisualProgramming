using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using WpfApplication3.Interfaces;

namespace WpfApplication3.Behaviour
{
    class FrameworkElementDragBehaviour : Behavior<FrameworkElement>
    {
        private bool isMouseClick = false;

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.MouseLeftButtonDown += new MouseButtonEventHandler(AssociatedObject_MouseLeftButtonDown);
            this.AssociatedObject.MouseLeftButtonUp += new MouseButtonEventHandler(AssociatedObject_MouseLeftButtonUp);
            this.AssociatedObject.MouseLeave += new MouseEventHandler(AssociatedObject_MouseLeave);
        }

        void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isMouseClick = true;
        }

        void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMouseClick = false;
        }

        void AssociatedObject_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isMouseClick)
            {
                IDragable dragObject = this.AssociatedObject.DataContext as IDragable;

                if (dragObject != null)
                {
                    DataObject data = new DataObject();
                    data.SetData(dragObject.DataType, this.AssociatedObject.DataContext);
                    DragDrop.DoDragDrop(this.AssociatedObject, data, DragDropEffects.Copy);
                }
            }
        }
    }
}
