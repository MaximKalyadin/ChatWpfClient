   M S B A M L   `   `   `  ����A  =ChatUi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ChatUi.ScreensChatUi.Screens  5   	   ?$clr-namespace:ChatUi.Custom_ControlsChatUi.Custom_Controls  64   $    ChatUi.Screens.ScreenMyProfile   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ChatUi.Screens     5   	   @Custom_Controls$clr-namespace:ChatUi.Custom_Controls     64   $
��Auto��5      $
��Auto��6(     � 	Resources  5      ��%    5
      .��5      � -   5         �Name$ GridMyProfile��5      $��0��6"   $��2��62    � RowDefinitions 5   
   �� 5      $��65 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ ButtonCloseMyProfile��5         ButtonStyle#��[  6/   $��Right=�6T   $��	0 35 13 0q�6p   $��25��6�   $��25��6�   .��5      �� $��/assets/close.png��6   $��20��6/   $��20��6;   5      �� 5   
   $��1��6    �� Orientation$ Vertical=�6"   $��	15 0 15 0q�69   .+�5      /   )ChatUi.Custom_Controls.RoundProfileButton  -   5          Name$ MyProfileImageScreen��5   1   $	��200��6O   $	��200��6\      StrokeBrush$ 
WhiteSmoke��6h   �� 5      -   5         ��Name$ NameSurnameTextBlock��5      $��0,18,0,0q�66    �� TextAlignment$ Center=�6H   $
��Bold"�6`   $��20(�6r   �� 5      -   5        $ CountryCityTextBlock��5      $��0,6,0,0q�66   $ Center=�6G   $��17(�6^   
���   �6l   �� 5      $	��350��6   
�������|�.  $��0,25,0,0q�6I   �� 5      $��	30,25,0,0q�6   $
 Left=�6+   �� 5      $�	Phone:   ��6   
�������$��14(�6?    �� 5      -   5        	 ��Name$	 PhoneRun��5      $��14(�6-   
�������6;   5      �� 5      $��	30,10,0,0q�6   $
 Left=�6+   �� 5      $�Nick:   ��6   
�������$��14(�6=    �� 5      -   5        $	 NickNameTextBlock��5      $��14(�67   
�������6E   5      �� 5       $	��350��6   
�������|�.  $��0,25,0,0q�6I   5!      5"      5$      