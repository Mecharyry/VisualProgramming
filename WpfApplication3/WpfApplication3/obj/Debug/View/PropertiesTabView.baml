   M S B A M L   `   `   `  ����J  FWpfApplication3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WpfApplication3.PropertiesGridWpfApplication3.PropertiesGrid  5      E'clr-namespace:WpfApplication3.ViewModelWpfApplication3.ViewModel  5      ,    &WpfApplication3.View.PropertiesTabView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      GPropertiesGrid,clr-namespace:WpfApplication3.PropertiesGrid     5      =	ViewModel'clr-namespace:WpfApplication3.ViewModel     5      -   5          >�Name$  UserControl��5
       � 	Resources 5      2   ,WpfApplication3.ViewModel.VariablesViewModel   	Variables  FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Item.MouseOver.Background �� Color  Item.MouseOver.Border $  Item.SelectedInactive.Background   Item.SelectedInactive.Border " Item.SelectedActive.Background  Item.SelectedActive.Border  VariableItemStyle �� 
TargetType �� RelativeSource	 �� AncestorType
 �� 
TargetType ��Name �� Padding �� CornerRadius �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName P� Property P� Value��%�  &	        &	      &	 �     &	 �     &	     &	 &    &	 I    &	 l    &	 �    7  7  7  7  7  7  7    5      6!   �� 5      .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6    . #��� ��68   $��1��6   $	 1 2R�6�   5      5      5      �� 5      $ 	#1F26A0DA��66   �� 5      $ 	#a826A0Da��62   �� 5      $ 	#3DDADADA��6=   �� 5      $ 	#FFDADADA��69   �� 5      $ 	#3D26A0DA��6;   �� 5      $ 	#FF26A0DA��67   �� 5       " ��6$   .�5!      ��  �@J�SnapsToDevicePixels . 6+   �� 5"       � ��$	 4,1q�6   �� 5#       � �� 62   �� *HorizontalContentAlignment+ �� "	 ���� 5$       � �� 60   �� *VerticalContentAlignment+ �� "	 ���� 5%       � ��
 ���� 6"   �� 5&       � ��
 ���� 6#   �� 5'       � ��$ 1q�6'   �� 5(       �@�FocusVisualStyle8   6(   �� 5)       � �� 5*      �� 5+      "
 ��6   .R�5,      �� $ Bd��6   # z��6    . $	��0,3q�6Z   $ 10��6p   
���OO/�._�5-   	   �� # z 6   $��Center=�6w   $��Center=�6�   ��6V   �� *VariableName+6�   5.   	    5/      ]� 50   	    51   
   �� 52       �@J�IsMouseOver . 6,   ./�54   
   �� $ Bd��6'   8   � ��67   �� 55   
   $ Bd��6(   8   � ��68   56   
   ]� 57   	    58   
   �� 59       �@��IsSelectionActive .  6;   �� 5:       �@��
IsSelected . 6+   ./�5<   
   �� $ Bd��6'   8   � ��67   �� 5=   
   $ Bd��6(   8   � ��68   5>   
   ]� 5?   	    5@   
   �� 5A       �@��IsSelectionActive . 6;   �� 5B       �@��
IsSelected . 6+   ./�5D   
   �� $ Bd��6'   8   � ��67   �� 5E   
   $ Bd��6(   8   � ��68   5F   
   P� 5G   	    � {� .  . �5H   
   �� $ Bd��63   # � ��6C    � ��5I   
   5K      5M      5N      5O      .��5Q      � -   5         �Name$ 
LayoutRoot��5Q       � RowDefinitions 5R      �� 5S      .+�5U      �� $
��Left=�6   $��684.232��6*   $	��Top=�6;   $��309.002��6S    	 TabHeaderTemplate#��� 	 6c   
����������	#FFACACAC 
 TabContentTemplate#��� 
 5V   /   $��	10,10,0,0q�6\   .@�5W      �� $��
Properties��6   $��Stretch=�6!   $
��Auto��6=   $��16(�6K   $��2,2,2,2q�6Y   .��5X      � .+�5Y      3   -WpfApplication3.PropertiesGrid.PropertiesGrid  -   5          Name$ gridProperties��5Y   %   $��10q�6=   $��Stretch=�6I   ��6e   Z� 5Z      5[      �� 5^      -   5         ��Name$ tabVariables��5^      $��	Variables��6#   $��Stretch=�66   $
��Auto��6R   $��16(�6`   $��2,2,2,2q�6n   .��5_      � $��0,0,-6,-9.247q�6    � ColumnDefinitions 5`      �� 5a      $��9* �6   �� 5b      $
��218* �6   �� 5c      $	��67* �6   �� 5d      $	��15* �6    5f      �� 5g      $	��70* �6   �� 5h      $
��441* �6   �� 5i      $	��44* �6   �� 5j      $	��26* �6   �� 5k      $	��59* �6   .+�5m      �� $	��Add��6   $��0,0,1.405,10q�6   $��Bottom=�62     ButtonStyle#���  6M   $��50��6s   $��2��6�   $��1,1,1,4q�6�   ��6�   �� *AddVariableCommand+��6�   ��  �� ElementName$ txtVariableName�� �� Path$
 Text��� 5n      $��Remove��6   $��136.101,5.762,10,7.725q�6   $��Center=�6?   #���  6Z   $��2��6�   $��1��6�   $��Right=�6�   $
��71.9��5o   �   ��6   �� *DeleteVariableCommand+��6G   �� $ lbxVariables��$ SelectedItem�6�   �� 5p      -   5         ��Name$ txtVariableName��5p       �� TextWrapping$
 Wrap=�6(   $��0q�6<    � ToolTip$ Variable Name��6}     TextboxStyle#���  5q      $��10,0,10,9.999q�6-   $��1��6D   $��Bottom=�6T   $��33.297��6�   ��5p   P   Z� ��6g   Z� ��5q   o   �� *!CurrentVariablesDB.VariableName+6�   �� 5s      -   5         ��Name$ lbxVariables��5s   e   $
��Left=�6   $��421.16��6*   $��	10,10,0,0q�6:   $	��Top=�6M   $��273.597��5t      ���	#FFC7C7C7#���  6D   $��1��5u   A   $��1��5v      $��2��6   $��	0,0.5,0,1q�6*   $	��0,5q�6F   $��2��6T   ��5t   .   Z� ��5u      �� *$"CurrentVariablesDB.GlobalVariables+5v   T   5w      5x      5y      5z      5{      