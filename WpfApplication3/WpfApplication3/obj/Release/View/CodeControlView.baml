   M S B A M L   `   `   `  ���� J  FWpfApplication3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication3WpfApplication3  *    $WpfApplication3.View.CodeControlView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  )localclr-namespace:WpfApplication3  -     >�Name$  UserControl�� � 	Resources    
ThumbStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Color �� Opacity J� BitmapEffect	 F� Color
 F� 	Direction F� ShadowDepth F� Softness F� Opacity  InformationStyle �� Triggers P� Property P� Value��%  &	        &	 �     �� " n�.���  � �� �� " n�.R�A� 
���OO/�$	��0.5������ $ 	#FFADBCFF��$	 0.2Q� F� $	 Black��$	
 320Q�$ 5Q�$	 0.5Q�$ 2Q��� " ��.���  � ��
 ����  P�  �@J�IsMouseOver . . ���  � ��
 �����.��(�  (� Stretch$
 Fill=�.��� $	��100��$	��100��
������ $��-20,-72,20,72q� � RowDefinitions �� $��4* ��� $	��17* ��� $��4* � � ColumnDefinitions �� $��9* ��� $	��82* ��� $��9* �.+���  � Cursor$ SizeAll��
������  K� ZIndex$ 1��$��3��$��3��n� -   $ SizeAll��$ 2��$��3��$��3��#��[  
��������� $��1��$��1������ *CurrentCodeModel.ImageSource+�� $��2q�$
��Left=�$��24��$	��Top=�$��24�� �� CornerRadius$ 20��
���OO/�#��[ $��1��$��	58,44,0,0q�$��1��$ 2��._��� $��i��$��-2q�$��Stretch=�$��Stretch=�$��Monotype Corsiva)�$��22.667(�$��7,0,5,5q�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseLeftButtonDown��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *SetPropertiesCommand+�� -   $��2q�$
��Left=�$��24��$	��Top=�$��24��$ 20��
���OO/�#��[ $��1��$��0,44,0,0q�$��1��$ 2��._��� $��l��$��-3.25,-0.625,-0.75,-3.375q�$��Stretch=�$��Stretch=�$��Monotype Corsiva)�$��22.667(�$��7,0,5,5q��� $��2q�$��24��$	��Top=�$ 20��
���OO/�#��[ $��1��$��29.004,0,28.996,0q�$ 2��$��2��   $ MouseLeftButtonDown��.    �� *RemoveControlCommand+._��� $��x��$��-3.25,-3.464,-0.75,-0.536q�$��Stretch=�$��Stretch=�$��Monotype Corsiva)�$��22.667(�$��7,0,5,5q�$ Arrow��