   M S B A M L   `   `   `  ����I  ESocial_network, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Social_network.ViewsSocial_network.Views  5      )    #Social_network.Views.UserPageStream   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Social_network.Views     5      -   5          N� Title$  UserPageStream��5	      .��5      � 
�������.+�5   
   �� $��Hidden=�6   .��5      �� -   5         ��Name$ mainStackUserContent��5      .+�5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5      �� -   5         ��Name$ blockFirstName��5       $��0��68   $��0��6F   $	��100��6W   $��30��6f   $��Right=�6r   $��Bottom=�6�   $��10q�6�   $��20(�6�   	Firs_name6�   �� 5    
   -   5        $ blockSecondName��5       $��0��6-   $��1��6:   $	��100��6J   $��30��6Y   $
��Left=�6e   $��Bottom=�6�   $��10q�6�   $��20(�6�   Second_name6�   �� 5!      -   5        $ 
blockEmail��5!       $��1��64   $��0��6A   $��2��6Q   $	��100��6e   $��30��6t   $	��Top=�6�   $��Center=�6�   $��10q�6�   $��20(�6�   email6�   �� 5"   
   $��1��6   $��2��6"   $��2��62   $��2��6F    �� Orientation$ 
Horizontal=�6W   .+�5#      �� $	��100��6   $��30��6'   $
��Left=�63   $	��Top=�6N   $��10q�6f   $
��Wrap=�6r   $��20(�6�   
Interests:6�   �� 5$      -   5        $ blockInterests��5$   $   $
��Wrap=�6<   $	��150��6P   $��60��6_   $	��Top=�6n   $��Center=�6�   $��10q�6�   $��14(�6�   	Some text6�   5%      �� 5&   
   -   5         ��Name$ bFollow��5&      $��3��6"   $��0��62   
�������
���� ��
�������$��20(�6{   $��30q�6�   .��6�   Follow6�   �� 5'   
   -   5        $ TextDistance��5'      $��
Distance: ��6*   $��3��6<   $��0��6L   $��Bottom=�6Y   $��10q�6t   $��Center=�6�   $��20��6�   $��50��6�   6�   5(      5)      5*      5+      5,      