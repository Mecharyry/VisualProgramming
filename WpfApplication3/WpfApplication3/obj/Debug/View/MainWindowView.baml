   M S B A M L   `   `   `  ����J  FWpfApplication3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfApplication3.ModelWpfApplication3.Model  5      ;"clr-namespace:WpfApplication3.ViewWpfApplication3.View  5      O,clr-namespace:WpfApplication3.PropertiesGridWpfApplication3.PropertiesGrid  5      E'clr-namespace:WpfApplication3.ViewModelWpfApplication3.ViewModel  5      1clr-namespace:WpfApplication3WpfApplication3  5      )    #WpfApplication3.View.MainWindowView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      5model#clr-namespace:WpfApplication3.Model     5      4local"clr-namespace:WpfApplication3.View     5      GPropertiesGrid,clr-namespace:WpfApplication3.PropertiesGrid     5      =	ViewModel'clr-namespace:WpfApplication3.ViewModel     5      9WpfApplication3clr-namespace:WpfApplication3     5      -   5          �Name$  UserControl��5       � Title$ 
MainWindow��5
      $
��1080��6   $
��1920��6&    � WindowState$ 	Maximized=�5       � 
ResizeMode$ NoResize=�5       � 	Resources 5      -   'WpfApplication3.ViewModel.MainViewModel   Tabs  ControlsLayoutTemplate K� IsItemsHost $� Orientation  TabTemplate ��Name �� Padding  ContentView'   !WpfApplication3.View.DesignerView��%�  &	        &	      &	 X     &	 k      5   
   6"   �� 5   
   .R�5      $�  . $ 
Horizontal=�65   5      �� 5   
   .R�5      �� $
��Auto��6   $��0q�6$   $
��Auto��6/   $��Stretch=�6<   .+�5      �� $ txtTabHeader��6   $��Stretch=�6J   $
��Auto��6f   $��Segoe UI)�6t   $��16(�6�   $
 5, 0q�6�   ��6,   �� *DesignerName+6�   5      5      �� 5   
   .R�5        5      5      	 � DataContext	 5       �� 5!   
   
 �� Source#
 [  6   .��5$      (�  (� Stretch$
 Fill=�6   .��5%      � $
��1051��6	   $
��1914��6   .+�5'      �� $��359.002,10,359.002,896.96q�6   $H��B/WpfApplication3;component/Resources/Images/Layout/macroMaker1.jpg��6.   �� 5)      -   5         ��Name$ 	tabDesign��5)        TabHeaderTemplate#���  6#   #���  5*   '    �� SelectedIndex$ 0��6T    �� ContentTemplate# �  5+      $��359.002,199,359.002,148q�6L   $��0q�6m     TabContentTemplate#���  6�   ��5*      �� *	Designers+��5+   5   Z� 6�   �� 5,      $��1574.998,199,10,148q�6   $��3,0,0,0q�6)    �� CornerRadius$ 10��6C    �� Padding$ 10,0,0,0q�6U   ._�5-      ,   &WpfApplication3.View.PropertiesTabView  $��	-13,0,0,0q�6   5.      �� 50      $��Generate��6   $��Right=�6   $��0,0,130.001,104.248q�6;   $��Bottom=�6X     ButtonStyle#���  6s   $��50��51      $��1,1,1,4q�6   $��16(�6I   ��6%   �� *GenerateCommand+6I   �� 53      $	��0,1q�6   $��359.002,189,359.002,211q�6"   
������� J� Effect 54      3  -System.Windows.Media.Effects.DropShadowEffect  55         ShadowDepth$ 2Q�6   57      �� 58      $	��1,0q�6   $��80,199,1639,221q�6"   
������� 59        5:      $ 2Q�6   ._�5<      .   (WpfApplication3.View.ApplicationListView  $��-1,0,-1,395q�6    $��0q�65   $	��Top=�6A   $��Center=�6Y   5=      �� 5>      $	��0,1q�6   $��359.002,923,359.002,10q�6"   
������� 5?        5@      $ 2Q�6   ._�5B      +   %WpfApplication3.View.ControlsListView  $��0,0,0,-2q�6   5C      o� 5E      $
��Left=�6
   $��20��6%   $	��Top=�61   $��35��6I   .@�5F      m� -   5         m�Name$
 File��5F      $
��File��6   .@�5G      m� -   5        $
 Open��5G      $
��Open��6   $
��Left=�6,   $��139.506666666667��6G    m� Command 6`   �� *OpenCommand+m� 5H      -   5        $
 Save��5H      $
��Save��6   $
��Left=�6,   $��139.506666666667��6G    6`   �� *SaveCommand+5I      5J      5K      5L      5M      