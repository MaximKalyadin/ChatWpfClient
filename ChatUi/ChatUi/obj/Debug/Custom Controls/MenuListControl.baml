   M S B A M L   `   `   `  ����A  =ChatUi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ChatUi.Custom_ControlsChatUi.Custom_Controls  5      ,    &ChatUi.Custom_Controls.MenuListControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:ChatUi.Custom_Controls     5      -   5          >�Name$  	_menuList��5      $
��Auto��62   $
��Auto��6?    � 	Resources 5         ChatListBox �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect  DropShadowInd   
BlurRadius   ShadowDepth   	Direction   Color  IndicatorStyle	 �� RelativeSource
 �� Mode �� AncestorType �� Triggers �� Binding �� Value  	PathStyle �� 
TargetType ��Name �� Padding J� SnapsToDevicePixels �� Triggers��%�  &	        &	     &	 b    7  &	     '�� �    7  7  �� 5	   
   " ��6$   .�5
      ��  � ��$ 0q�60   �� 5       � ��
 ���� 6+   �� 5       � ��$ Stretch=�62   �� 5       � ��$ Stretch=�64   �� 5       �@��SelectionMode$ Single=�6.   �� 5       � |� .  6*   5        5   
   $ 10Q�61   $ 3Q�6A   $	 360Q�6Q   $ #f54a4a��6a   �� 5   
   " ��6'   .�5      ��  � �� �#f54a4a6+   �� 5       � y�$ Hidden=�6+   �� 5       � �� 6'   �� *Height+	 �� $
 FindAncestor=�$ BorderL��� 5       � ��$ 4��6&   �� 5       � |� .  6*   �� 5       � ��$
 Left=�64   �� 5       �@J�Effect8   6'    5      �� 5       6   �� *IsMouseOver+	 �� $
 FindAncestor=�$ ListBoxItemL� True6�   .a�5      ��  � y�$ Visible=�63   5      �� 5        6   �� *
IsSelected+	 �� $
 FindAncestor=�$ ListBoxItemL� True6�   .a�5!      ��  � y�$ Visible=�63   5"      5$      �� 5%   
   " F�6"   .�5&      ��  � ��
 � E��6%   �� 5'       � ��$ 26��6&   �� 5(       �@��Stretch$ Uniform=�6(   �� 5)       � ��$ Stretch=�64    5*      �� 5+       6   �� *IsMouseOver+	 �� $
 FindAncestor=�" �� True6�   .a�5,      ��  � �� �#2A2E4D6-   5-      �� 5.       6   �� *
IsSelected+	 �� $
 FindAncestor=�" �� True6�   .a�5/      ��  � �� �#2A2E4D6-   50      52      �� 53   
   " ��6   .�54      ��  � ��$ 74��6'   �� 55       �@��
IsSelected 6+   �� *IsItemSelected+�� 56       � ��
 ���� 6+   �� 57       � ��$ 0q�60   �� 58       � �� 59      �� 5:      " ��6&   .R�5;      �� $ border��6!   #��z��61   # z��6[   #��z��6   #��z��6�    . ._�5=      � $��-4,0,0,0q�6#   .+�5>   "   �� 8��  6)   F� 5?   "   8�� ��6'   �� *
PathData+6A   5@      5A       5B      �� 5C      $	 130��6M    6*   �� *ListItemHeight+.a�5D   "   ��  � ��$	 270��6;   �� 5E   "    � {� .  6>   5F      5H      5J      5K      5L      .��5M      �� -   5         ��Name$ ListBoxMenu��5M   T   #��[  6   ��63   �� *
ItemList+6T   5N      