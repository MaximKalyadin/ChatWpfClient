   M S B A M L   `   `   `  ����A  =ChatUi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ChatUiChatUi  5      a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes 61       
ChatUi.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      &localclr-namespace:ChatUi     5      ]ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     61     �� 	Resources  5         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle �� 
TargetType �� 
TargetType ��Name	 �� CornerRadius
 ��Name �� Triggers P� Property P� Value �� 
TargetName  ComboBox.Static.Background  ComboBox.Static.Border ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background * &ComboBox.Static.Editable.Button.Border  ComboBox.MouseOver.Glyph ! ComboBox.MouseOver.Background  ComboBox.MouseOver.Border * &ComboBox.MouseOver.Editable.Background & "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Glyph  ComboBox.Pressed.Background  ComboBox.Pressed.Border ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border  ComboBox.Disabled.Glyph    ComboBox.Disabled.Background ! ComboBox.Disabled.Border )" %ComboBox.Disabled.Editable.Background %# !ComboBox.Disabled.Editable.Border 0$ ,ComboBox.Disabled.Editable.Button.Background ,% (ComboBox.Disabled.Editable.Button.Border & ComboBox.Static.Glyph ' ComboBoxToggleButton F�Name �� Stretch ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value ( ComboBoxTemplate �Name � ColumnDefinitions �Name � AllowsTransparency �� Mode5  /Microsoft.Windows.Themes.SystemDropShadowChrome  Name   Color �� MaxDropDownHeight �� ElementName ��Name  �� ClearTypeHint! ��Name" ��Name# ��Name-  'System.Windows.Input.KeyboardNavigation$   DirectionalNavigation% d�Name& d� 	IsChecked' �� SelectionBoxItemTemplate( �� SelectionBoxItem#) �� SelectionBoxItemStringFormat* �� ContentStringFormat+ J� IsHitTestVisible, P� 
SourceName- ]� 
Conditions. �� Property ) TextBox.Static.Background * ComboBoxEditableTextBox + ComboBoxEditableTemplate/ ��Name0 �� 
IsReadOnly , ComboBoxStyle11 �� Triggers��%�1  &	        &	 �     &	 �     &	 �     &	     &	 2    &	 O    &	 r    &	 �    &		 �    &	
 �    7  7  7  7  7  7  7  7  7 	 &	     &	 5    &	 X    &	 }    &	 �    &	 �    &	 �    &	     &	 2    &	 U    &	 z    &	 �    &	 �    &	 �    &	 	    &	 -	    &	 P	    &	 u	    &	 �	    &	 �	    &	 �	    &	  
    &	! (
    &	" K
    &	# p
    &	$ �
    &	% �
    &	& �
    &	'      7  7  7 & 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7   7 ! 7 " 7 # 7 $ 7 % &	( �    7 ' &	) I     &	* l     &	+ �"    7 ' 7 ) 7 * &	, �+    7   7  7  7 ( 7 + �� 5   
   .�5      ��  � �� 5      �� 5	      .R�5
      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ #2A2E4D��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ #2A2E4D��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $	 Red��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6$   .�5      ��  � ��8   6+   �� 5       � ��8  6,   �� 5       � ��# � ��6+   �� 5       � ��$ 0q�60   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�6;   �� 5        � ��$ Center=�69   �� 5!       � ��$ 30��6'   �� 5"       � ��$ 30��6&   �� 5#       � |� .  6*   �� 5$       � �� 5%      �� 5&      " ��6&   .R�5'      �� $ border��6!   #��z��61   #��z��6]   $	 20��6�   #��z��6�    . ._�5(      �� $
 contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5)       5*      P� 5+       �@��IsDefaulted . . �5,   "   �� $ border��6@   # � ��6T    � ��5-      P� 5.       �@J�IsMouseOver . . �5/   "   �� $ border��6?   8   � ��6S   �� 50   "   $ border��6@   8   � ��6T   51      P� 52       � �� . . �53   "   �� $ border��6?   8   � ��6S   �� 54   "   $ border��6@   8   � ��6T   55      P� 56       � {� .  . �57   "   �� $ border��6?   8   � ��6S   �� 58   "   $ border��6@   8   � ��6T   �� 59   "   $ contentPresenter��6K   8   � ��6i   5:      5<      5>      5?      �� 5B   
   $ Transparent��6=   �� 5C   
   $ 	#FFACACAC��69   �� 5D   
   $ Transparent��6F   �� 5E   
   $ 	#FFABADB3��6B   �� 5F   
   $ Transparent��6M   �� 5G   
   $ Transparent��6I   �� 5H   
   $ 	#FF000000��6;   �� 5I   
   $ Transparent��6@   �� 5J   
   $ 	#FF7EB4EA��6<   �� 5K   
   $ Transparent��6I   �� 5L   
   $ 	#FF7EB4EA��6E   �� 5M   
   $ Transparent��6P   �� 5N   
   $ 	#FF7EB4EA��6L   �� 5O   
   $ 	#FF000000��69   �� 5P   
   $ Transparent��6>   �� 5Q   
   $ 	#FF569DE5��6:   �� 5R   
   $ Transparent��6G   �� 5S   
   $ 	#FF569DE5��6C   �� 5T   
   $ Transparent��6N   �� 5U   
   $ 	#FF569DE5��6J   �� 5V   
   $ 	#FFBFBFBF��6:   �� 5W   
   $ Transparent��6?   �� 5X   
   $ 	#FFD9D9D9��6;   �� 5Y   
   $ Transparent��6H   �� 5Z   
   $ 	#FFBFBFBF��6D   �� 5[   
   $ Transparent��6O   �� 5\   
   $ Transparent��6K   �� 5]   
   $ 	#FF606060��68   �� 5^   
   " d�6-   .�5_      ��  �@�OverridesDefaultStyle . 66   �� 5`       � �� .  6*   �� 5a       � ��$ 0q�60   �� 5b       � |� .  6*   �� 5c       �@��	ClickMode$ Press=�6*   �� 5d       � �� 5e      �� 5f      " d�6&   .R�5g      �� $ templateRoot��6!   8��  #��z��6m   8��  . ._�5h      �� $ splitBorder��6%   
������ $��0q�6T   $��Right=�6h   $��0q�6�    . #��� r�6�   ._�5i   "   F� $ arrow��6'   F����        ���( ��( јaQ     јaQ P����̰( � �    P����        8�� $��10��6�   $ Uniform=�6�   $��Center=�6�   $��0q�6�   $��Center=�6
  5j      5k       5l      ^� 5m       5n   "   �� 5o   &    60   �� *
IsEditable+ �� " �� true6�   �� 5p   &    60   �� *IsMouseOver+ �� *Self+	 false6v   �� 5q   &    60   �� *	IsPressed+ �� *Self+	 false6t   �� 5r   &    60   �� *	IsEnabled+ �� *Self+ true6t   .0�5t   "   �� $ templateRoot��6?   8   � ��6Y   �� 5u   "   $ templateRoot��6@   8   � ��6Z   �� 5v   "   $ splitBorder��6?   8   � ��6X   �� 5w   "   $ splitBorder��6@   8   � ��6Y   5x      P� 5y       �@J�IsMouseOver . . �5z   "   �� $ arrow��69   8   � ��6L   5{      ^� 5|       5}   "   �� 5~   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8 	  � ��6Z   5�      ^� 5�       5�   "   �� 5�   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5�   &    60   �� *
IsEditable+ �� " �� true6�   .0�5�   "   �� $ templateRoot��6?   8 
  � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   �� 5�   "   $ splitBorder��6?   8   � ��6X   �� 5�   "   $ splitBorder��6@   8   � ��6Y   5�      P� 5�       � �� . . �5�   "   �� $ arrow��69   8   � ��6L   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsPressed+ �� *Self+ true6t   �� 5�   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   5�      P� 5�       � {� .  . �5�   "   �� $ arrow��69   8   � ��6L   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5�   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5�   &    60   �� *
IsEditable+ �� " �� true6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   �� 5�   "   $ splitBorder��6?   8   � ��6X   �� 5�   "   $ splitBorder��6@   8   � ��6Y   5�      5�      5�      5�      �� 5�   
   " ��63   .R�5�      � $ templateRoot��6    .  5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   $��1q�6�   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5�        $ shadow��64   $ Transparent��6D   #��z 6X   ��6�   �� *ActualWidth+$ templateRoot��._�5�      �� $ dropDownBorder��6!   #��� ��69   $��1q�6�   #��� ��6�   ._�5�      �� $ DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $  Enabled=�65   .+�5�   &   �� $! canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $" 
opaqueRect��64   ��6H   �� *
Background+$ dropDownBorder����6�   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5�   '   �� 5�   &   $# ItemsPresenter��65   $$ 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $% toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  & 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+66  �� 5�      $
 contentPresenter��6#   #��z' 6=   #��z��6z   #��z( 6�   #* z) 6�   #��z��6-  + .  #��z��6�  # z 6�  #��z��6�  5�       5�      P� 5�      $, 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $ shadow��6/    � ��$ 0,0,5,5q�6C   �� 5�      $ shadow��6.    �@ Color$ 	#71000000��6B   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6/    � ��$ 95��6K   5�      ]� 5�      - 5�      �� 5�      . �@��
IsGrouping . 6:   �� 5�      ". �@%�IsVirtualizingWhenGrouping .  6\   ./�5�      ��  � �� .  6F   5�      P� 5�      $, DropDownScrollViewer��6C    � �� .  . �5�      �� $ 
opaqueRect��63    6K   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5�      $ 
opaqueRect��64    6L   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5�      5�      �� 5�   
   $ 	#FFFFFFFF��6<   �� 5�   
   " ��60   .�5�      ��  �@�OverridesDefaultStyle . 66   �� 5�       �@J�	AllowDrop . 6*   �� 5�       � ��$ 0��6)   �� 5�       � ��$ 0��6*   �� 5�       �@�FocusVisualStyle 61   Z� �� 5�       �@��PanningMode$ VerticalFirst=�69   �� 5�       �@��IsFlicksEnabled .  67   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $ PART_ContentHost��6'   
������ |�.  $��Hidden=�6l   $��Hidden=�6�   5�      5�      5�      �� 5�   
   " ��6;   .R�5�      � $ templateRoot��6    .  5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+ �� *TemplatedParent+.��5�        $ shadow��64   $ Transparent��6D   #��z 6X   ��6�   �� *ActualWidth+$ templateRoot��._�5�      �� $ dropDownBorder��6!   #��� ��69   $��0q�6�   #��� ��6�   ._�5�      �� $ DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $  Enabled=�65   .+�5�   &   �� $! canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $" 
opaqueRect��64   ��6H   �� *
Background+$ dropDownBorder����6�   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5�   '   �� 5�   &   $# ItemsPresenter��65   $$ 	Contained=�6M   # z 6�   5�   #   5      5     5     5     d� 5     $% toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  & 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+66  �� 5     $ border��6   8�� #��z��6a   ._�5     �� $/ PART_EditableTextBox��6   #��z��6<   #��z��6�   8�� #��z��6-  0 6�   �� *
IsReadOnly+ �� *TemplatedParent+6-  5     5      5	     P� 5
      � {� .  . �5     �� $ border��60    �@J�Opacity$
 0.56Q�6D   5     P� 5      �@J�IsKeyboardFocusWithin . . �5     ��  � ��
 �   �63   5     P� 5     $, 
PART_Popup��63    �@�HasDropShadow . . �5     �� $ shadow��6/    � ��$ 0,0,5,5q�6C   �� 5     $ shadow��6.    �@ Color$ 	#71000000��6B   5     P� 5      �@��HasItems .  . �5     �� $ dropDownBorder��6/    � ��$ 95��6K   5     ]� 5     - 5     �� 5     . �@��
IsGrouping . 6:   �� 5     ". �@%�IsVirtualizingWhenGrouping .  6\   ./�5     ��  � �� .  6F   5     P� 5     $, DropDownScrollViewer��6C    � �� .  . �5     �� $ 
opaqueRect��63    6K   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5      $ 
opaqueRect��64    6L   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5!     5#     �� 5$  
   " ��6'   .�5%     ��  �@�FocusVisualStyle8   61   �� 5&      � ��8  6+   �� 5'      � ��8  6,   �� 5(      � ��# � ��6+   �� 5)      � ��$ 0q�60   �� 5*      � ��$
 Auto=�6K   �� 5+      � ��$
 Auto=�6I   �� 5,      � �� . 6>   �� 5-      �@��PanningMode$
 Both=�69   �� 5.      �@��IsFlicksEnabled .  67   �� 5/      � |� .  6*   �� 50      �@��SelectedIndex$ 0��6.   �� 51      � ��$
 Left=�64   �� 52      � ��$ Center=�62   �� 53      � ��$	 100��6&   �� 54      � ��$ 15(�6)   �� 55      � ��$
 10,0q�6'   �� 56      � ��8  6)   1 57     P� 58      �@��
IsEditable . . �59     ��  � �� .  62   �� 5:      � ��$ 2q�60   �� 5;      � ��8  61   5<     5>     5?     5A     