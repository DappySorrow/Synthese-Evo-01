   M S B A M L   `   `   `  ����>  :UIL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UILUIL  5          UIL.UCListerLesVentes   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:UIL     5        � 	Resources  5       �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid��%�   '��       '  �     �� 5   
   " ��6   .�5      ��  � ��
 ��  �6+   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�64   5      �� 5   
   "  6   .�5      ��  � ��
 �����6+   5      5      .��5      � -   5           DarkBackground#��[  5        � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��8* �6   �� 5      $��* �6   .+�5"   
   � $��0��6   .+�5#        -   5        $��dgVentes��5#         
IsReadOnly .    AutoGenerateColumns .     Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Province��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *
Province+  5&      $	 TypeVeh��6)   $
 * 6:    6D   �� *	TypeVeh+  5'      $	 Annee��6)   $
 * 68    6B   �� *Annee+  5(      $	 NbUnites��6)   $
 * 6;    6E   �� *
NbUnites+  5)      $	 Mntx1000��6)   $
 * 6;    6E   �� *
Mntx1000+5+      5,      � 5/   
   $��1��6   .+�50      �� .+�52      �� $��Type d'affichage��6   �� 54      -   5        $��cbTrier��54   '   $��23��6   $	��260��66   .@�55      �� $$��Ordre décroissant des années��6#   �� 56      $%��Ordre décroissant des NbUnites��6#   �� 57      $1��+Ordre décroissant des prix moyens de vente��6#   58      59      5;      5<      5=      