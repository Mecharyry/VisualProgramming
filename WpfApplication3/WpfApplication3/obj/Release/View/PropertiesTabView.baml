   M S B A M L   `   `   `  ���� J  FWpfApplication3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WpfApplication3.PropertiesGridWpfApplication3.PropertiesGrid  E'clr-namespace:WpfApplication3.ViewModelWpfApplication3.ViewModel  ,    &WpfApplication3.View.PropertiesTabView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     GPropertiesGrid,clr-namespace:WpfApplication3.PropertiesGrid     =	ViewModel'clr-namespace:WpfApplication3.ViewModel     -     >�Name$  UserControl�� � 	Resources 2   ,WpfApplication3.ViewModel.VariablesViewModel   	Variables  FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Item.MouseOver.Background �� Color  Item.MouseOver.Border $  Item.SelectedInactive.Background   Item.SelectedInactive.Border " Item.SelectedActive.Background  Item.SelectedActive.Border  VariableItemStyle �� 
TargetType �� RelativeSource	 �� AncestorType
 �� 
TargetType ��Name �� Padding �� CornerRadius �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName P� Property P� Value��%�  &	        &	      &	 S     &	 h     &	 }     &	 �     &	 �     &	 �     &	 �     7  7  7  7  7  7  7    �� .���  � �� �� .R��� $��2q� . #��� ��$��1��$	 1 2R��� $ 	#1F26A0DA���� $ 	#a826A0Da���� $ 	#3DDADADA���� $ 	#FFDADADA���� $ 	#3D26A0DA���� $ 	#FF26A0DA���� " ��.���  �@J�SnapsToDevicePixels . ��  � ��$	 4,1q���  � �� �� *HorizontalContentAlignment+ �� "	 ����  � �� �� *VerticalContentAlignment+ �� "	 ����  � ��
 ���� ��  � ��
 ���� ��  � ��$ 1q���  �@�FocusVisualStyle8   ��  � �� �� "
 ��.R��� $ Bd��# z�� . $	��0,3q�$ 10��
���OO/�._��� # z $��Center=�$��Center=����� *VariableName+ ]�  ��  �@J�IsMouseOver . ./��� $ Bd��8   � ���� $ Bd��8   � ��]�  ��  �@��IsSelectionActive .  ��  �@��
IsSelected . ./��� $ Bd��8   � ���� $ Bd��8   � ��]�  ��  �@��IsSelectionActive . ��  �@��
IsSelected . ./��� $ Bd��8   � ���� $ Bd��8   � ��P�  � {� .  . ��� $ Bd��# � �� � ��.��� -    �Name$ 
LayoutRoot�� � RowDefinitions �� .+��� $
��Left=�$��684.232��$	��Top=�$��309.002�� 	 TabHeaderTemplate#��� 	 
����������	#FFACACAC 
 TabContentTemplate#��� 
 $��	10,10,0,0q�.@��� $��
Properties��$��Stretch=�$
��Auto��$��16(�$��2,2,2,2q�.��� .+�3   -WpfApplication3.PropertiesGrid.PropertiesGrid  -     Name$ gridProperties��$��10q�$��Stretch=���Z� �� -    ��Name$ tabVariables��$��	Variables��$��Stretch=�$
��Auto��$��16(�$��2,2,2,2q�.��� $��0,0,-6,-9.247q� � ColumnDefinitions �� $��9* ��� $
��218* ��� $	��67* ��� $	��15* � �� $	��70* ��� $
��441* ��� $	��44* ��� $	��26* ��� $	��59* �.+��� $	��Add��$��0,0,1.405,10q�$��Bottom=�  ButtonStyle#���  $��50��$��2��$��1,1,1,4q����� *AddVariableCommand+����  �� ElementName$ txtVariableName�� �� Path$
 Text��� $��Remove��$��136.101,5.762,10,7.725q�$��Center=�#���  $��2��$��1��$��Right=�$
��71.9������ *DeleteVariableCommand+���� $ lbxVariables��$ SelectedItem��� -    ��Name$ txtVariableName�� �� TextWrapping$
 Wrap=�$��0q� � ToolTip$ Variable Name��  TextboxStyle#���  $��10,0,10,9.999q�$��1��$��Bottom=�$��33.297����Z� ��Z� ���� *!CurrentVariablesDB.VariableName+�� -    ��Name$ lbxVariables��$
��Left=�$��421.16��$��	10,10,0,0q�$	��Top=�$��273.597�����	#FFC7C7C7#���  $��1��$��1��$��2��$��	0,0.5,0,1q�$	��0,5q�$��2����Z� ���� *$"CurrentVariablesDB.GlobalVariables+