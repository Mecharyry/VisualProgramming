   M S B A M L   `   `   `  ����   WpfApplication3    WpfApplication3.App   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       �� 	Resources     FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle �� 
TargetType �� 
TargetType ��Name	 �� Padding
 �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName  TextBox.Static.Border  TextBox.MouseOver.Border  TextBox.Focus.Border  TextboxStyle-  'System.Windows.Input.KeyboardNavigation ��Name �� Triggers ]� 
Conditions �� Property �� Value  TabContentTemplate � RowDefinitions K� ZIndex K� IsItemsHost  TabHeaderTemplate J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   	Direction   ShadowDepth   Color��%.  &	        &	 N     &	 c     &	 x     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     7   7  7  7  7  7  7  7  7  7 	 &	 ?    &	 T    &	 i    &	 ~    7  7  7  &	 �    &	 �	    �� .���  � �� �� .R��� $��2q� . #��� ��$��1��$	 1 2R��� $ 	#FFDDDDDD���� $ 	#FF707070���� $ 	#FFBEE6FD���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � ��$ 24����  � ��$ 50����  � �� �� " ��.R��� $ border�� . $	��0,3q�$	 0q�$��0q�$
 10��
���OO/�
�������$��Center=�._��� $ contentPresenter��|�.  #��z��#��z����. # z #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  �@J�IsMouseOver . . ��� $ border��8   � ���� $ border��8   � ��P�  � �� . . ��� $ border��8   � ���� $ border��8   � ��P�  � {� .  . ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8 	  � ���� $ 	#FFABAdB3���� $ 	#FF7EB4EA���� $ 	#FF569DE5���� " ��.���  � ��# � ����  � ��8   ��  � ��# � ����  � ��$ 1q���  �@ TabNavigation$
 None=���  � ��$
 Left=���  �@�FocusVisualStyle Z� ��  �@J�	AllowDrop . ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R��� $ border��#��z�� . 
���OO/�$	��0,3q�$
 10��._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=�$	��5,1q� P�  � {� .  . ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsMouseOver . . ��� $ border��8   � ��P�  �@J�IsKeyboardFocused . . ��� $ border��8   � �� ]�  �� + �@��#IsInactiveSelectionHighlightEnabled . ��  �@��IsSelectionActive .  ./���  �@��SelectionBrush# � /��� " ��.���  � �� �� " ��.R�� $��0,1,0,0q� �� $	��59* ��� $��6* �.+��� $��1��$��1��$
��Auto��$��Center=�$��Center=�$��1175.996��$��0,3,0,0q�$
 10��$	 5,10,5,5q�$��10,6.009q���Z� ._��� $ 1�� . 
������ $
��Auto��$
��Auto��$��Center=�$��Center=�$��0q��� $��0��$��3q�$
 10��$��1��$��0,0,0,3.333q����	#FFEEEEEE��Z� ._��� $��SelectedContent��$
��0,-1q�$
��Auto���� " ��.���  � �� �� " ��.R�� $	��NaN��$	��NaN��$��5,-8.667,5,0q�$��Stretch=�.+��� $ 
brdTabItem��$��0,3,0,0q�$
 8��$
��Auto��$
��Left=�$��Stretch=�$��5,10,5,3.667q�$	 0,0,5,0q�$
��Auto����Z� ��Z� ._�� $
��Auto��$
��Auto��$��0.25,0,-12.924,0q�.+��� $ ContentSite��$
��Left=�$��Header��$��2.416,0,10,3q�$
��Auto��$
��Auto���� $ brdTabItem_Copy�����	#00ADD8E6
�������$��0,0,3,0q�$
 0��$
��Auto��$��Right=�$��0q�$		 5,0q�$
��Auto��   $ 5Q�$	 315Q�$ 2Q�$ Black�� P�  �@��
IsSelected . . ��� $ 
brdTabItem�� � ��
 ��ح�P�  �@��
IsSelected .  . ��� $ 
brdTabItem�� � ��
 �����