   M S B A M L   `   `   `  ���� J  FWpfApplication3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WpfApplication3.BehaviourWpfApplication3.Behaviour  ;"clr-namespace:WpfApplication3.ViewWpfApplication3.View  E'clr-namespace:WpfApplication3.ViewModelWpfApplication3.ViewModel  =#clr-namespace:WpfApplication3.ModelWpfApplication3.Model  '    !WpfApplication3.View.DesignerView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  /b'clr-namespace:WpfApplication3.Behaviour  .local"clr-namespace:WpfApplication3.View  7	viewModel'clr-namespace:WpfApplication3.ViewModel  /model#clr-namespace:WpfApplication3.Model  -     >�Name$  UserControl�� � 	Resources -  'System.Windows.Data.CompositeCollection   Col �� 
Collection �� Source%  System.Windows.Markup.Reference �� DataType0   *WpfApplication3.ViewModel.ControlViewModel*   $WpfApplication3.View.CodeControlView+   %WpfApplication3.Model.ConnectionModel ��Name	 �� X1	 �� Y1	 �� X2		 �� Y2
 �� Triggers �� Binding �� Value �� 
TargetName �� Property �� Value&    WpfApplication3.Model.StartModel+   %WpfApplication3.View.StartControlView��%�  &	        (�� �     *, +)(�� �     *, +)(�� �    *, +)  ��  �� *DataContext.Controls+   *UserControl+��  �� *DataContext.Connections+   *UserControl+��  �� *DataContext.StartControl+   *UserControl+�� "  .R�  �� "  .R��� $
 Line��
���  ��$��3�� �� *	Start.X+ �� *	Start.Y+ �� *End.X+	 �� *End.Y+
 ��  �� *End+ Z� .a��� $
 Line�� � y�$ 	Collapsed=��� "  .R�  .��� .+��� -    �� SelectedItem �� *CurrentControl+��Z� ����  �� ResourceKey$	 Col������ .R���  ��Name$ canvasDesigner��-    J� 	AllowDrop . 
������ .  (System.Windows.Interactivity.Interaction   	Behaviors =	  7WpfApplication3.Behaviour.FrameworkElementDropBehaviour	  ����  �� 
TargetType" ��.���  �@��Left �� *X+ �� Mode$ TwoWay=���  �@��Top �� *Y+$ TwoWay=���  � �� ��  �� 
TargetType" ��.R���  ��Name$ Content��$��Center=�$��Center=�$��0q� �� Triggers P�  P� Property �@��
IsSelected P� Value . . ��� $ Content�� �@J�Effect 3
  -System.Windows.Media.Effects.DropShadowEffect
   
  Color$ 	CadetBlue�� 
  ShadowDepth$ 2Q� 
  
BlurRadius$ 5Q�