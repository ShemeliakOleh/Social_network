   M S B A M L   `   `   `  ����I  ESocial_network, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Social_network.ViewsSocial_network.Views  5   	   #    Social_network.Views.MainUser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Social_network.Views     5   	   -   5          � Title$  MainUser��5   	   $	��600��6   $
��1000��6'   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   6,   �� 5      $	��10* �6   6.   �� 5      $
��0.5* �6   6.    � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      $	��15* �6   6+   �� 5      6   .+�5   
   �� -   5         ��Name$ UserName��5      $��0��6&   $��0��66   $
��Left=�6C   $��8q�6^   $��Center=�6i   $��25(�6�   6�    � 5   
   -   5          �Name$ mainPage��5   0     � NavigationUIVisibility$ Hidden=�6   $��1��6B   $��1��6R   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� -   5        $��bStream��5      $
��Left=�6$   $	��100��6?   
���� ��
�������
�������$��20(�6�   .��6�   Stream6�   �� 5      -   5        $��bSearch��5      $
��Left=�6$   $	��100��6?   
���� ��
�������
�������$��20(�6�   .��6�   Search6�   �� 5      -   5        $��
bFollowing��5      $
��Left=�6'   $	��100��6B   
���� ��
�������
�������$��20(�6�   .��6�   	Following6�   �� 5      -   5        $��
bFollowers��5      $
��Left=�6'   $	��100��6B   
���� ��
�������
�������$��20(�6�   .��6�   	Followers6�   5      �� 5   
   -   5         ��Name$ bLogOut��5      $��0��6"   
���  ��$��2��6H   $��18(�6U   
�������
�������.��6�   	Log out6�   5!      5"      