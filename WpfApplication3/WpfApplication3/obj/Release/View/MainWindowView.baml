   M S B A M L   `   `   `  ���� J  FWpfApplication3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfApplication3.ModelWpfApplication3.Model  ;"clr-namespace:WpfApplication3.ViewWpfApplication3.View  O,clr-namespace:WpfApplication3.PropertiesGridWpfApplication3.PropertiesGrid  E'clr-namespace:WpfApplication3.ViewModelWpfApplication3.ViewModel  1clr-namespace:WpfApplication3WpfApplication3  )    #WpfApplication3.View.MainWindowView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5model#clr-namespace:WpfApplication3.Model     4local"clr-namespace:WpfApplication3.View     GPropertiesGrid,clr-namespace:WpfApplication3.PropertiesGrid     =	ViewModel'clr-namespace:WpfApplication3.ViewModel     9WpfApplication3clr-namespace:WpfApplication3     -     �Name$  UserControl�� � Title$ 
MainWindow��$
��1080��$
��1920�� � WindowState$ 	Maximized=� � 
ResizeMode$ NoResize=� � 	Resources -   'WpfApplication3.ViewModel.MainViewModel   Tabs  ControlsLayoutTemplate K� IsItemsHost $� Orientation  TabTemplate ��Name �� Padding  ContentView'   !WpfApplication3.View.DesignerView��%	  &	        &	      &	 *     &	 �       �� .R�$�  . $ 
Horizontal=��� .R��� $
��Auto��$��0q�$
��Auto��$��Stretch=�.+��� $ txtTabHeader��$��Stretch=�$
��Auto��$��Segoe UI)�$��16(�$
 5, 0q����� *DesignerName+�� .R�  	 � DataContext	 �� 
 �� Source#
 [  .��(�  (� Stretch$
 Fill=�.��� $
��1051��$
��1914��.+��� $��359.002,10,359.002,896.96q�$H��B/WpfApplication3;component/Resources/Images/Layout/macroMaker1.jpg���� -    ��Name$ 	tabDesign��  TabHeaderTemplate#���  #���   �� SelectedIndex$ 0�� �� ContentTemplate# �  $��359.002,199,359.002,148q�$��0q�  TabContentTemplate#���  ���� *	Designers+��Z� �� $��1574.998,199,10,148q�$��3,0,0,0q� �� CornerRadius$ 10�� �� Padding$ 10,0,0,0q�._�,   &WpfApplication3.View.PropertiesTabView  $��	-13,0,0,0q��� $��Generate��$��Right=�$��0,0,130.001,104.248q�$��Bottom=�  ButtonStyle#���  $��50��$��1,1,1,4q�$��16(����� *GenerateCommand+�� $	��0,1q�$��359.002,189,359.002,211q�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 2Q��� $	��1,0q�$��80,199,1639,221q�
�������   $ 2Q�._�.   (WpfApplication3.View.ApplicationListView  $��-1,0,-1,395q�$��0q�$	��Top=�$��Center=��� $	��0,1q�$��359.002,923,359.002,10q�
�������   $ 2Q�._�+   %WpfApplication3.View.ControlsListView  $��0,0,0,-2q�o� $
��Left=�$��20��$	��Top=�$��35��.@�m� -    m�Name$
 File��$
��File��.@�m� -   $
 Open��$
��Open��$
��Left=�$��139.506666666667�� m� Command �� *OpenCommand+m� -   $
 Save��$
��Save��$
��Left=�$��139.506666666667�� �� *SaveCommand+