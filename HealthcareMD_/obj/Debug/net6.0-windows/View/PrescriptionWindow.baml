   M S B A M L   `   `   `  ����H  DHealthcareMD_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HealthcareMD_.DoctorWindowsHealthcareMD_.DoctorWindows  5   	   A%clr-namespace:HealthcareMD_.ViewModelHealthcareMD_.ViewModel  6A   4    .HealthcareMD_.DoctorWindows.PrescriptionWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Hi:http://schemas.microsoft.com/expression/2010/interactivity     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:HealthcareMD_.DoctorWindows     5   	   ;	viewmodel%clr-namespace:HealthcareMD_.ViewModel     6A     � Title$  Recept��5	   	   $	��391��6   $	��306��6%   $��	Yu Gothic)�61    J� InputBindings 5      �� 5   
    �� 	Modifiers$ Controlf�5      
 �� Key$ X��5       �� Command 5      �� *CloseCommand+�� 5   
   $ Controlf�5      $ S��5       5      �� *AcceptCommand+ � 	Resources 5         highlightRow �� Triggers �� Binding �� Path	 �� Value
 �� Property �� Value��%�   &	        �� 5   
   .R�5      �� ��6   �� *
MyProperty+ 5      �� 5       6   �� $ 
isAllergic�$
	 true��5   )   a�5      �� 5      
 � ��
 �  ��6?   5       5#      5$      .��5'      � ���	#FFCBF4E7.+�5(   
   �� ���	#FF4C7F82$��4q�6)    �� CornerRadius$ 8,8,8,8��6=   $��10,10,10,85q�6T   ���	#FF99E1D9._�5)      &   System.Windows.Controls.DataGrid  -   5          Name$ 	drugTable��5)      "   VerticalScrollBarVisibility$
 Auto=�6*      AutoGenerateColumns$ False��6�      
IsReadOnly$
 True��6�      SelectionMode$ Single=�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $��6,10,6,6q�6�      GridLinesVisibility$ 
Horizontal=�6  ���	#FF345F61��6M   �� *Drugs+ �� UpdateSourceTrigger$ PropertyChanged=���6�   Z� ��6/  Z�  5*      �� 5,      $ Controlf�5-      $ Space��5.       5/      �� *ShowCommand+ 51      )  #System.Windows.Controls.DataGridRow �� 
TargetType��%E   '        �� 52      "  6   .�53      -   5        54      56         	CellStyle 57      �� 58      *  $System.Windows.Controls.DataGridCell"  6    �� Triggers 59      �� 5:       6*   �� *
IsAllergic+	 true6I   .a�5;   "   �� 
 � �� �	#FFF33C3C6?   �� 5<   "   
 � ��
 �����6?   5=      5?         Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6)      MaxWidth$ 0Q�65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Id+  5C      $	 Ime��6)    66   �� *Name+  5D      $	 Tip��6)    66   �� *Type+5F      5G      �� 5H   
   ���	#FF4C7F82���#70ABAF$��3q�6>   $ 8��6R   $��62,272,165,10q�6c   ._�5J      �� -   5         ��Name$ Schedule��5J      $��-13,-13,-13,-29q�6'   ��6[   Z� ��6r   Z� .��5K      �� $��73��6   $��75��6)   .+�5L      �� $ ��/Resources/acceptWhite.png��6   $��Uniform=�6@   $��36��6R   $��33��6^   �� 5M      $��Prihvati [S]��6   $��Center=�63   
�������$��43��6j   $��76��6v   $��11(�6�   5O      5P      5R      �� 5S   
   ���	#FF4C7F82���#70ABAF$��3q�6>   $ 8��6R   $��172,272,53,10q�6c   ._�5T      �� -   5        ��5T   0   Z� ��6G   Z� .��5U      �� $��59��6   $��88��6)   $��Center=�64   .+�5V      �� $ ��/Resources/cancelWhite.png��6   $��Uniform=�6@   $��37��6R   $��38��6^   �� 5W      $��Otkaži [X]��6   $��Center=�61   
�������$��11(�6h   5X      5Y      5Z      5\      5]      