   M S B A M L   `   `   `  ����A  =ChatUi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ChatUi.Custom_ControlsChatUi.Custom_Controls  5   	   /clr-namespace:ChatUi.ScreensChatUi.Screens  5   	   clr-namespace:ChatUiChatUi  5   	   b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5   	       ChatUi.MainWindow   5   	   8Custom_Controls$clr-namespace:ChatUi.Custom_Controls  (Screensclr-namespace:ChatUi.Screens  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:ChatUi     5   	   ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5   	   -   5          �Name$  
mainWindow��5	       � Title$ 
MainWindow��5
   	   $	��800��6   $
��1400��6)   
���  ��$��2q�6H    � WindowStyle$
 None=�6\    � 
ResizeMode$ 	CanResize=�6o    � WindowStartupLocation$ CenterScreen=�6�    � AllowsTransparency . ��5      �� 5   
    �� ImageSource$3 -assets/AuthorizationWindowBackgroundImage.jpg��6    j� Stretch$ UniformToFill=�6Q    � 	Resources 5         FocusVisual	 �� Property
 �� Value J� SnapsToDevicePixels �� StrokeDashArray  ComboBox.Static.Background �� Color  ComboBox.Static.Border ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background * &ComboBox.Static.Editable.Button.Border  ComboBox.MouseOver.Glyph ! ComboBox.MouseOver.Background 	 ComboBox.MouseOver.Border *
 &ComboBox.MouseOver.Editable.Background & "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Glyph  ComboBox.Pressed.Background  ComboBox.Pressed.Border ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border  ComboBox.Disabled.Glyph   ComboBox.Disabled.Background  ComboBox.Disabled.Border ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBox.Static.Glyph  ComboBoxToggleButton �� 
TargetType �� 
TargetType ��Name F�Name �� Stretch �� Triggers ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value �� 
TargetName P� Property P� Value  ComboBoxTemplate �Name � ColumnDefinitions �Name � AllowsTransparency  �� Mode5  /Microsoft.Windows.Themes.SystemDropShadowChrome!  Name"   Color# �� MaxDropDownHeight$ �� ElementName% ��Name& �� ClearTypeHint' ��Name( ��Name) ��Name-  'System.Windows.Input.KeyboardNavigation*   DirectionalNavigation+ d�Name, d� 	IsChecked- ��Name. �� SelectionBoxItemTemplate/ �� SelectionBoxItem#0 �� SelectionBoxItemStringFormat1 �� ContentStringFormat2 J� IsHitTestVisible3 P� 
SourceName4 ]� 
Conditions5 �� Property  TextBox.Static.Background   ComboBoxEditableTextBox ! ComboBoxEditableTemplate6 ��Name7 �� 
IsReadOnly " ComboBoxStyle18 �� Triggers # Button.Static.Background $ Button.Static.Border % Button.MouseOver.Background & Button.MouseOver.Border ' Button.Pressed.Background ( Button.Pressed.Border ) Button.Disabled.Background * Button.Disabled.Border + Button.Disabled.Foreground , ButtonStyle9 �� CornerRadius - SendMessageButtonStyle: �� BasedOn . ButtonStyleFriendBorder / SystemButtonStyle 0 MyButtonStyleMyProfile��%?  &	        &	 �     &	 �     &	 �     &	     &	 :    &	 _    &	 �    &	 �    &		 �    &	
 �    &	     &	 7    &	 \    &	     &	 �    &	 �    &	 �    &	     &	 2    &	 W    &	 z    &	 �    &	 �    &	 �    &	 
    &	 -    &	 R    &	 w    &	 �    7  7  7  7  7  7  7  7  7  7 	 7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  &	 f    7  &	 �    &	      &	! &    7  7  7   &	" �%    7   7  7  7  7 ! &	# )    &	$ <)    &	% _)    &	& �)    &	' �)    &	( �)    &	) �)    &	* 
*    &	+ -*    &	, P*    7   7 # 7 $ 7 % 7 & 7 ' 7 ( 7 ) 7 * 7 + &	- �/    7 , &	. �1    7   7 ' 7 ( 7 ) 7 * 7 + &	/ �6    7   7 ' 7 ) 7 * 7 + &	0 G;    �� 5   
   .�5      �� 	 � ��
 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ Transparent��6=   �� 5   
   $ 	#FFACACAC��69   �� 5   
   $ Transparent��6F   �� 5   
   $ 	#FFABADB3��6B   �� 5   
   $ Transparent��6M   �� 5   
   $ Transparent��6I   �� 5   
   $ 	#FF000000��6;   �� 5   
   $ Transparent��6@   �� 5    
   $ 	#FF7EB4EA��6<   �� 5!   
   $ Transparent��6I   �� 5"   
   $ 	#FF7EB4EA��6E   �� 5#   
   $ Transparent��6P   �� 5$   
   $ 	#FF7EB4EA��6L   �� 5%   
   $ 	#FF000000��69   �� 5&   
   $ Transparent��6>   �� 5'   
   $ 	#FF569DE5��6:   �� 5(   
   $ Transparent��6G   �� 5)   
   $ 	#FF569DE5��6C   �� 5*   
   $ Transparent��6N   �� 5+   
   $ 	#FF569DE5��6J   �� 5,   
   $ 	#FFBFBFBF��6:   �� 5-   
   $ Transparent��6?   �� 5.   
   $ 	#FFD9D9D9��6;   �� 5/   
   $ Transparent��6H   �� 50   
   $ 	#FFBFBFBF��6D   �� 51   
   $ Transparent��6O   �� 52   
   $ Transparent��6K   �� 53   
   $ 	#FF606060��68   �� 54   
   " d�6-   .�55      �� 	 �@�OverridesDefaultStyle
 . 66   �� 56      	 � ��
 .  6*   �� 57      	 � ��$
 0q�60   �� 58      	 � |�
 .  6*   �� 59      	 �@��	ClickMode$
 Press=�6*   �� 5:      	 � ��
 5;      �� 5<      " d�6&   .R�5=      �� $ templateRoot��6!   8��  #��z��6m   8��  . ._�5>      �� $ splitBorder��6%   
������ $��0q�6T   $��Right=�6h   $��0q�6�    . #��� r�6�   ._�5?   "   F� $ arrow��6'   F����        ���( ��( јaQ     јaQ P����̰( � �    P����        8�� $��10��6�   $ Uniform=�6�   $��Center=�6�   $��0q�6�   $��Center=�6
  5@      5A       5B      ^� 5C       5D   "   �� 5E   &    60   �� *
IsEditable+ �� " �� true6�   �� 5F   &    60   �� *IsMouseOver+ �� *Self+	 false6v   �� 5G   &    60   �� *	IsPressed+ �� *Self+	 false6t   �� 5H   &    60   �� *	IsEnabled+ �� *Self+ true6t   .0�5J   "   �� $ templateRoot��6?   8
  	 � ��6Y   �� 5K   "   $ templateRoot��6@   8
  	 � ��6Z   �� 5L   "   $ splitBorder��6?   8
  	 � ��6X   �� 5M   "   $ splitBorder��6@   8
  	 � ��6Y   5N      P� 5O       �@J�IsMouseOver . . �5P   "   �� $ arrow��69   8
  	 � ��6L   5Q      ^� 5R       5S   "   �� 5T   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5U   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5W   "   �� $ templateRoot��6?   8
  	 � ��6Y   �� 5X   "   $ templateRoot��6@   8
 	 	 � ��6Z   5Y      ^� 5Z       5[   "   �� 5\   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5]   &    60   �� *
IsEditable+ �� " �� true6�   .0�5_   "   �� $ templateRoot��6?   8
 
 	 � ��6Y   �� 5`   "   $ templateRoot��6@   8
  	 � ��6Z   �� 5a   "   $ splitBorder��6?   8
  	 � ��6X   �� 5b   "   $ splitBorder��6@   8
  	 � ��6Y   5c      P� 5d       � �� . . �5e   "   �� $ arrow��69   8
  	 � ��6L   5f      ^� 5g       5h   "   �� 5i   &    60   �� *	IsPressed+ �� *Self+ true6t   �� 5j   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5l   "   �� $ templateRoot��6?   8
  	 � ��6Y   �� 5m   "   $ templateRoot��6@   8
  	 � ��6Z   5n      P� 5o       � {� .  . �5p   "   �� $ arrow��69   8
  	 � ��6L   5q      ^� 5r       5s   "   �� 5t   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5u   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5w   "   �� $ templateRoot��6?   8
  	 � ��6Y   �� 5x   "   $ templateRoot��6@   8
  	 � ��6Z   5y      ^� 5z       5{   "   �� 5|   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5}   &    60   �� *
IsEditable+ �� " �� true6�   .0�5   "   �� $ templateRoot��6?   8
  	 � ��6Y   �� 5�   "   $ templateRoot��6@   8
  	 � ��6Z   �� 5�   "   $ splitBorder��6?   8
  	 � ��6X   �� 5�   "   $ splitBorder��6@   8
  	 � ��6Y   5�      5�      5�      5�      �� 5�   
   " ��63   .R�5�      � $ templateRoot��6    .  5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   $��1q�6�   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+$  TwoWay=� �� *TemplatedParent+.��5�        $! shadow��64   $" Transparent��6D   #��z# 6X   ��6�   �� *ActualWidth+$$ templateRoot��._�5�      �� $ dropDownBorder��6!   #��� ��69   $��1q�6�   #��� ��6�   ._�5�      �� $% DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $& Enabled=�65   .+�5�   &   �� $' canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $( 
opaqueRect��64   ��6H   �� *
Background+$$ dropDownBorder����6�   �� *ActualHeight+$$ dropDownBorder����6�   �� *ActualWidth+$$ dropDownBorder��5�   '   �� 5�   &   $) ItemsPresenter��65   $* 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $+ toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  , 6�   �� *IsDropDownOpen+$  TwoWay=� �� *TemplatedParent+66  �� 5�      $- contentPresenter��6#   #��z. 6=   #��z��6z   #��z/ 6�   #1 z0 6�   #��z��6-  2 .  #��z��6�  # z 6�  #��z��6�  5�       5�      P� 5�      $3 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $ shadow��6/   	 � ��$
 0,0,5,5q�6C   �� 5�      $ shadow��6.   	 �@ Color$
 	#71000000��6B   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6/   	 � ��$
 95��6K   5�      ]� 5�      4 5�      �� 5�      5 �@��
IsGrouping . 6:   �� 5�      "5 �@%�IsVirtualizingWhenGrouping .  6\   ./�5�      �� 	 � ��
 .  6F   5�      P� 5�      $3 DropDownScrollViewer��6C    � �� .  . �5�      �� $ 
opaqueRect��63   
 6K   �� *VerticalOffset+$$ DropDownScrollViewer��	 �@��Top�� 5�      $ 
opaqueRect��64   
 6L   �� *HorizontalOffset+$$ DropDownScrollViewer��	 �@��Left5�      5�      �� 5�   
   $ 	#FFFFFFFF��6<   �� 5�   
   " ��60   .�5�      �� 	 �@�OverridesDefaultStyle
 . 66   �� 5�      	 �@J�	AllowDrop
 . 6*   �� 5�      	 � ��$
 0��6)   �� 5�      	 � ��$
 0��6*   �� 5�      	 �@�FocusVisualStyle
 61   Z� �� 5�      	 �@��PanningMode$
 VerticalFirst=�69   �� 5�      	 �@��IsFlicksEnabled
 .  67   �� 5�      	 � ��
 5�      �� 5�      " ��6&   .R�5�      �� $% PART_ContentHost��6'   
������ |�.  $��Hidden=�6l   $��Hidden=�6�   5�      5�      5�      �� 5�   
   " ��6;   .R�5�      � $ templateRoot��6    .  5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+ �� *TemplatedParent+.��5�        $! shadow��64   $" Transparent��6D   #��z# 6X   ��6�   �� *ActualWidth+$$ templateRoot��._�5�      �� $ dropDownBorder��6!   #��� ��69   $��0q�6�   #��� ��6�   ._�5�      �� $% DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $& Enabled=�65   .+�5�   &   �� $' canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $( 
opaqueRect��64   ��6H   �� *
Background+$$ dropDownBorder����6�   �� *ActualHeight+$$ dropDownBorder����6�   �� *ActualWidth+$$ dropDownBorder��5�   '   �� 5�   &   $) ItemsPresenter��65   $* 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $+ toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  , 6�   �� *IsDropDownOpen+$  TwoWay=� �� *TemplatedParent+66  �� 5�      $ border��6   8�� #��z��6a   ._�5�      �� $6 PART_EditableTextBox��6   #��z��6<   #��z��6�   8�� #��z��6-  7 6�   �� *
IsReadOnly+ �� *TemplatedParent+6-  5�      5�       5�      P� 5�       � {� .  . �5�      �� $ border��60   	 �@J�Opacity$

 0.56Q�6D   5�      P� 5�       �@J�IsKeyboardFocusWithin . . �5�      �� 	 � ��

 �   �63   5�      P� 5�      $3 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $ shadow��6/   	 � ��$
 0,0,5,5q�6C   �� 5�      $ shadow��6.   	 �@ Color$
 	#71000000��6B   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6/   	 � ��$
 95��6K   5�      ]� 5�      4 5�      �� 5�      5 �@��
IsGrouping . 6:   �� 5�      "5 �@%�IsVirtualizingWhenGrouping .  6\   ./�5�      �� 	 � ��
 .  6F   5�      P� 5�      $3 DropDownScrollViewer��6C    � �� .  . �5�      �� $ 
opaqueRect��63   
 6K   �� *VerticalOffset+$$ DropDownScrollViewer��	 �@��Top�� 5�      $ 
opaqueRect��64   
 6L   �� *HorizontalOffset+$$ DropDownScrollViewer��	 �@��Left5�      5�      �� 5�   
   " ��6'   .�5�      �� 	 �@�FocusVisualStyle8
   61   �� 5�      	 � ��8
  6+   �� 5�      	 � ��8
  6,   �� 5�      	 � ��#
 � ��6+   �� 5�      	 � ��$
 0q�60   �� 5      	 � ��$

 Auto=�6K   �� 5     	 � ��$

 Auto=�6I   �� 5     	 � ��
 . 6>   �� 5     	 �@��PanningMode$

 Both=�69   �� 5     	 �@��IsFlicksEnabled
 .  67   �� 5     	 � |�
 .  6*   �� 5     	 �@��SelectedIndex$
 0��6.   �� 5     	 � ��$

 Left=�64   �� 5     	 � ��$
 Center=�62   �� 5	     	 � ��$	
 100��6&   �� 5
     	 � ��$
 15(�6)   �� 5     	 � ��$

 10,0q�6'   �� 5     	 � ��8
  6)   8 5     P� 5      �@��
IsEditable . . �5     �� 	 � ��
 .  62   �� 5     	 � ��$
 2q�60   �� 5     	 � ��8
  61   5     5     �� 5  
   $ #F54A4A��6;   �� 5  
   $ 	#FF707070��67   �� 5  
   $ #F54A4A��6>   �� 5  
   $ 	#FF3C7FB1��6:   �� 5  
   $ #F54A4A��6<   �� 5  
   $ 	#FF2C628B��68   �� 5  
   $ 	#FFF4F4F4��6=   �� 5  
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5#  
   " ��6$   .�5$     �� 	 �@�FocusVisualStyle8
   61   �� 5%     	 � ��8
  6+   �� 5&     	 � ��8
  6,   �� 5'     	 � ��#
 � ��6+   �� 5(     	 � ��$
 0q�60   �� 5)     	 � ��$
 Center=�64   �� 5*     	 � ��$
 Center=�62   �� 5+     	 � ��$
 Center=�6;   �� 5,     	 � ��$
 Center=�69   �� 5-     	 � ��$
 30��6'   �� 5.     	 � ��$
 30��6&   �� 5/     	 � |�
 .  6*   �� 50     	 � ��
 51     �� 52     " ��6&   .R�53     �� $ border��6!   #��z��61   #��z��6]   $9 20��6�   #��z��6�    . ._�54     �� $- contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  55      56     P� 57      �@��IsDefaulted . . �58  "   �� $ border��6@   #
 � ��6T   	 � ��59     P� 5:      �@J�IsMouseOver . . �5;  "   �� $ border��6?   8
  	 � ��6S   �� 5<  "   $ border��6@   8
  	 � ��6T   5=     P� 5>      � �� . . �5?  "   �� $ border��6?   8
  	 � ��6S   �� 5@  "   $ border��6@   8
  	 � ��6T   5A     P� 5B      � {� .  . �5C  "   �� $ border��6?   8
  	 � ��6S   �� 5D  "   $ border��6@   8
  	 � ��6T   �� 5E  "   $ contentPresenter��6K   8
 	 	 � ��6i   5F     5H     5J     5K     �� 5L  
   " ��6/   8:   .�5M     �� 	 � |�
 .  6*   �� 5N     	 � ��$
 55��6'   �� 5O     	 � ��$
 55��6&   �� 5P     	 � ��$
 Right=�64   �� 5Q     	 � ��$
 Center=�6;   �� 5R     	 � ��
 5S     �� 5T     " ��6&   .R�5U     �� $ border��6!   #��z��61   #��z��6]   #��z��6�   $9 50��6�    . ._�5V     �� |�.  #��z��6A   ��. # z 6~   #��z��6�   5W     5X     5Z     5[     �� 5_  
   " ��60   .�5`     �� 	 �@�FocusVisualStyle8
   61   �� 5a     	 � ��
 �#2A2E4D6+   �� 5b     	 � ��

 �����6,   �� 5c     	 � ��

 �����6+   �� 5d     	 � ��$
 1q�60   �� 5e     	 � ��$
 16(�6)   �� 5f     	 � ��$
 Center=�6;   �� 5g     	 � ��$
 Center=�69   �� 5h     	 � ��$
 8q�6(   �� 5i     	 � ��
 5j     �� 5k     " ��6&   .R�5l     �� $ border��6!   $9 2��61   #��z��6B   #��z��6n   #��z��6�    . ._�5m     �� $- contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5n      5o     P� 5p      �@��IsDefaulted . . �5q  "   �� $ border��6@   #
 � ��6T   	 � ��5r     P� 5s      �@J�IsMouseOver . . �5t  "   �� $ border��6?   	 � ��
 �#2A2E4D6S   �� 5u  "   	 � ��$
 18(�6=   �� 5v  "   $ border��6@   	 � ��

 �����6T   5w     P� 5x      � �� . . �5y  "   �� $ border��6?   8
  	 � ��6S   �� 5z  "   $ border��6@   8
  	 � ��6T   5{     P� 5|      � {� .  . �5}  "   �� $ border��6?   8
  	 � ��6S   �� 5~  "   $ border��6@   8
  	 � ��6T   �� 5  "   $ contentPresenter��6K   8
  	 � ��6i   5�     5�     5�     5�     �� 5�  
   " ��6*   .�5�     �� 	 �@�FocusVisualStyle8
   61   �� 5�     	 � ��

 ���� 6+   �� 5�     	 � ��

 ���� 6,   �� 5�     	 � ��#
 � ��6+   �� 5�     	 � ��$
 0q�60   �� 5�     	 � ��$
 Center=�6;   �� 5�     	 � ��$
 Center=�69   �� 5�     	 � ��$
 1q�6(   �� 5�     	 � ��
 5�     �� 5�     " ��6&   .R�5�     �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5�     �� $- contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5�      5�     P� 5�      �@��IsDefaulted . . �5�  "   �� $ border��6@   #
 � ��6T   	 � ��5�     P� 5�      �@J�IsMouseOver . . �5�  "   �� $ contentPresenter��6)   	 �@J�Opacity$	
 0.5Q�6Z   5�     P� 5�      � �� . . �5�  "   �� $ border��6?   8
  	 � ��6S   5�     P� 5�      � {� .  . �5�  "   �� $ border��6?   8
  	 � ��6S   �� 5�  "   $ border��6@   8
  	 � ��6T   �� 5�  "   $ contentPresenter��6K   8
  	 � ��6i   5�     5�     5�     5�     �� 5�  
   " ��6/   .�5�     �� 	 � ��

 ���� 6+   �� 5�     	 � ��
 5�     �� 5�     " ��6&   .R�5�     � #��z��6   .+�5�     �� $��Center=�6/   $��Center=�5�     5�     5�     5�     5�     5�     .��5�     �  5�  
   �� 5�     -   5        ; ��Name$; MenuList��5�  *   $��95 �6   6*   �� 5�     -   5        $; RightRegion��5�  )   $��* �6   6)   .+�5�  
   � $��0��6   $��2��6   < J� Opacity$	< 0.8Q�60   
�������= � RowDefinitions= 5�     �� 5�     $	��100 �6    �� 5�     $��* �6    .+�5�     �� -   5        > ��Name$> ButtonProfile��5�     #��[0 6,   ��5�     /   )ChatUi.Custom_Controls.RoundProfileButton  5�     -   5        ?  Name$? 	myProfile��5�  9   $��50��6L   @   ProfileImageSource$@ /assets/profile1.jpg��6W   5�     ,   &ChatUi.Custom_Controls.MenuListControl  5�     -   5        A  Name$
A Menu��5�  M   ,   &ChatUi.Custom_Controls.MenuListControlB   ListBoxSelectedIndex$B Menu_ListBoxSelectedIndex��6[   $��1��6.   $��0,30,0,0q�6;   6[   5�     !   ChatUi.Screens.ScreenFriend  5�  
   -   5        C  Name$C Friend��5�     $��1��6/   $y�	Collapsed=�6?      ChatUi.Screens.ScreenChat  5�  
   -   5        D  Name$
D Chat��5�     $��1��6+   $y�	Collapsed=�6;   #   ChatUi.Screens.ScreenSettings  5�  
   -	   5        E  Name$E Settings��5�  !   $��1��63   $y�	Collapsed=�6C   �� 5�  
   $��1��6   $��Right=�6%   $	��Top=�6A   F �� Orientation$F 
Horizontal=�6Y   $��0 5 10 0q�6r   .+�5�     �� -
   5        $> CompressButton��5�     
������ 
������ $��30��5�     $��30��6    $��0 0 5 0q�6,   #��� / 6=   .��5�     �� -   5        G ��Name$G CompressImage��5�     $+��%assets/systembuttons/compress32px.png��6/   $��25��6^   $��25��6i   5�     �� 5�     -   5        $> FitToWidthButton��5�     
������ 
������ $��30��5�     $��30��6    $��5 0 5 0q�6,   #��� / 6=   .��5�     �� -   5        $G FitToWidthImage��5�     $.��(assets/systembuttons/fitToWidth_32px.png��61   $��26��6c   $��26��6n   5�     �� 5�     -   5        $> CloseButton��5�     
������ 
������ $��30��5�     $��30��6    $��5 0 0 0q�6,   #��� / 6=   .��5�     �� -   5        $G 
CloseImage��5�     $+��%assets/systembuttons/multiply32px.png��6,   $��32��6[   5�     5�     5�     5�     