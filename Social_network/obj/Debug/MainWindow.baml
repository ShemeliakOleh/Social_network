   M S B A M L   `   `   `  ����I  ESocial_network, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Social_networkSocial_network  5   	       Social_network.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Social_network     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��550��6)   $	��370��65   $	��400��6E   .��5	      �  � ShowGridLines .   � ColumnDefinitions 5
   
   �� 5      6!   �� 5      $
��2.5* �6   6.   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��0.7* �6   6,   �� 5      $
��1.5* �6   6,   �� 5      $
��1.5* �6   6-   �� 5      6   �� 5      6   .+�5   
   �� $��1��6   $��1��6!   $��Center=�61   $	��Top=�6N   $��45��6f   $	��200��6r   $��24(�6~   $��12q�6�    �� TextAlignment$ Center=�6�   $��Enter e-mail��6�   6�   �� 5   
   -   5         ��Name$ 	tBoxEmail��5      $��1��6%   $��1��62   $��Center=�6B   $��Bottom=�6_   $��19(�6z   $��Light"�6�   $��30��6�   $	��250��6�   $��20q�6�    �� TextAlignment$ Center=�6�   6�   �� 5   
   $��2��6   $��1��6!   $��Center=�61   $	��Top=�6N   $��45��6f   $	��200��6r   $��24(�6~   $��12q�6�   $ Center=�6�   $��Enter password��6�   6�   �� 5   
   -   5        $ tBoxPassword��5      $��2��6(   $��1��65   $��Center=�6E   $��Bottom=�6b   $��19(�6}   $��Light"�6�   $��30��6�   $	��250��6�   $��20q�6�   $ Center=�6�   6�   �� 5   
   -   5         ��Name$ SingIn��5      $��1��6!   $��3��61   $��40��6>   $	��150��6J   $��Log in��6V   $��25(�6g   6�   �� 5   
   -   5        $ SingUp��5      $��1��6!   $��4��61   $��38��6>   $	��200��6J   $��Register��6V   $��24(�6i   6�   �� 5   
   -   5         ��Name$ tBlockIncorrectLogin��5      $��0��62   $��1��6?   $��Center=�6O   $��Center=�6l   $��18(�6�   
���  ��$#��Incorrect e-mail or password!��6�   $y�Hidden=�6�   6�   5      5      