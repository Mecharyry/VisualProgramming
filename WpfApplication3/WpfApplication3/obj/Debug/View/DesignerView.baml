   M S B A M L   `   `   `  ����J  FWpfApplication3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WpfApplication3.BehaviourWpfApplication3.Behaviour  5      ;"clr-namespace:WpfApplication3.ViewWpfApplication3.View  5      E'clr-namespace:WpfApplication3.ViewModelWpfApplication3.ViewModel  5	      =#clr-namespace:WpfApplication3.ModelWpfApplication3.Model  5
      '    !WpfApplication3.View.DesignerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      /b'clr-namespace:WpfApplication3.Behaviour  5      .local"clr-namespace:WpfApplication3.View  5      7	viewModel'clr-namespace:WpfApplication3.ViewModel  5	      /model#clr-namespace:WpfApplication3.Model  5
      -   5          >�Name$  UserControl��5       � 	Resources 5      -  'System.Windows.Data.CompositeCollection   Col �� 
Collection �� Source%  System.Windows.Markup.Reference �� DataType0   *WpfApplication3.ViewModel.ControlViewModel*   $WpfApplication3.View.CodeControlView+   %WpfApplication3.Model.ConnectionModel ��Name	 �� X1	 �� Y1	 �� X2		 �� Y2
 �� Triggers �� Binding �� Value �� 
TargetName �� Property �� Value&    WpfApplication3.Model.StartModel+   %WpfApplication3.View.StartControlView��%$  &	        (��     5      *, +)(�� ?    5      *, +)(�� �    5(      *, +)  5   
   �� 5       6"   �� *DataContext.Controls+   *UserControl+�� 5       6"   �� *DataContext.Connections+   *UserControl+�� 5       6"   �� *DataContext.StartControl+   *UserControl+5      �� 5   
   "  6   .R�5        6&   5      �� 5   
   "  6   .R�5      �� $
 Line��5   G   
���  ��$��3��5        5      �� *	Start.X+ 64   �� *	Start.Y+ 5      �� *End.X+	 62   �� *End.Y+6G   
 5       �� 5!       6   �� *End+ 66   Z� .a�5"      �� $
 Line��6    � y�$ 	Collapsed=�6E   5#      5%      �� 5(      "  6   .R�5)        6   5*      5+      .��5-      � .+�5.   
   �� -   5         �� SelectedItem 5.      �� *CurrentControl+��6h   Z� ��5/      �� 50       �� ResourceKey$	 Col��6   ��52      �� 53      .R�54      ��  ��Name$ canvasDesigner��6   -   5         J� 	AllowDrop . 
������ .  (System.Windows.Interactivity.Interaction   	Behaviors 55      =	  7WpfApplication3.Behaviour.FrameworkElementDropBehaviour	  56      58      59      ��5;      �� 5<       �� 
TargetType" ��6   .�5=      ��  �@��Left 64   �� *X+ �� Mode$ TwoWay=��� 5>       �@��Top 63   �� *Y+$ TwoWay=��� 5?       � �� 5@      �� 5A       �� 
TargetType" ��6.   .R�5B   "   ��  ��Name$ Content��63   $��Center=�6D   $��Center=�6a   $��0q�6|    �� Triggers 5C   "   P� 5D   &    P� Property �@��
IsSelected P� Value . . �5E   *   �� $ Content��61    �@J�Effect 5F   .   3
  -System.Windows.Media.Effects.DropShadowEffect
  5G   2    
  Color$ 	CadetBlue��6C    
  ShadowDepth$ 2Q�6U    
  
BlurRadius$ 5Q�6e   5I   +   5J   '   5L      5N      5O      5Q      5R      5S      