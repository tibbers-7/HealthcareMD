   M S B A M L   `   `   `  ����H  DHealthcareMD_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthcareMD_.ViewHealthcareMD_.View  5   	   -clr-namespace:HealthcareMD_HealthcareMD_  5   	   A%clr-namespace:HealthcareMD_.ViewModelHealthcareMD_.ViewModel  6;   *    $HealthcareMD_.View.PatientReportForm   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hi:http://schemas.microsoft.com/expression/2010/interactivity     5   	   2local clr-namespace:HealthcareMD_.View     5   	   5HealthcareMD_clr-namespace:HealthcareMD_     5   	   ;	viewmodel%clr-namespace:HealthcareMD_.ViewModel     6;     � Title$  PatientReportForm��5
   	   $	��276��6#   $	��469��60   ���	#FFCBF4E7 J� InputBindings 5      �� 5   
    �� 	Modifiers$ Controlf�5      
 �� Key$ X��5       �� Command 5      �� *CloseCommand+�� 5   
   $ Controlf�5      $ S��5       5      �� *AcceptCommand+ � 	Resources 5         validationTemplate � RowDefinitions � ColumnDefinitions ��Name��%M  &	        �� 5   
   .R�5      � $
��Auto��6   $
��Auto��6!    5      �� 5       5      �� 5      �� 5      $
��Auto �6'   .+�5       �� $ textBox��6I   $��0��6,   $��0��6<   6I   �� 5!      $��1��6   $��0��6,   
���  ����69   �� *[0].ErrorContent+6[   5"      5#      5%      .��5&      � .+�5(   
   �� -   5        	 ��Name$	 startDate_tb��5(      $��22,79,253,130q�6(   
 =� ErrorTemplate#
 [  6?    J� RenderTransformOrigin$ -3.078,-0.132&�6~   ���	#FF4C7F82.��6�   .��5)      ��  �� Path$ 	StartDate�6    �� UpdateSourceTrigger$ 	LostFocus=�6'    �� ValidationRules 5*      "   HealthcareMD_.DateValidation  5+      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�63   +   %HealthcareMD_.RequiredFieldValidation  5,      $ RawProposedValue=�6<   5.      5/      �� 50   
   -   5        $	 
endDate_tb��50      $��249,79,22,130q�6&   #
 [  6=   $ -3.078,-0.132&�6|   ���	#FF4C7F82.��6�   .��51      �� $ EndDate�6   $ 	LostFocus=�6%    52        53      $ RawProposedValue=�63     54      $ RawProposedValue=�6<   56      57      �� 59   
   ���	#FF4C7F82���#70ABAF$��3q�6>    �� CornerRadius$ 8��6R   $��138,135,251,27q�6c   ._�5:      �� -   5         ��Name$ 
ReportBttn��5:      $��	0,-1,0,-1q�6)   $��Center=�6�   $��80��6�   ��6T   Z� ��6k   Z� .��5;      �� $��Stretch=�6   $��64��69   $��79��6E   $��Center=�6P   .+�5<      �� $ ��/Resources/acceptWhite.png��6   $��Uniform=�6@   $��36��6R   $��33��6^   �� 5=      $��Prihvati [S]��6   
�������$��29��6F   $��64��6R   $��11(�6]   $��Center=�6k   5?      5@      5B      �� 5C   
   ���	#FF4C7F82���#70ABAF$��3q�6>   $ 8��6R   $��235,135,154,27q�6c   ._�5D      �� -   5        $��	-3,0,-3,0q�5D   ]   ��60   Z� ��6G   Z� .��5E      �� $��66��6   $��70��6)   $��Center=�64   $��Center=�6Q   .+�5F      �� $ ��/Resources/cancelWhite.png��6   $��Uniform=�6@   $��37��6R   $��38��6^   $��Center=�6i   $��Center=�6�   �� 5G      $��Otkaži [X]��6   $��Center=�61   
�������$��64��6h   $��Center=�6s   $��Center=�6�   $��11(�6�   5H      5I      5J      �� 5K   
   ���	#FF4C7F82���	#FF70ABAF$��3q�6@   $ 3��6T   $��22,10,22,186q�6e   ._�5L      �� 
�������$��Center=�6H   $��20(�6l   ��6   �� *PatientName+6l   5M      �� 5N   
   $��__��6   $��Center=�6   $��0,74,0,0q�6:   $	��Top=�6L   $ 1.446,0.057&�6d   ���	#FF284B4E$��20(�6�   �� 5O   
   $	��Od:��6   $��22,77,361,149q�6   ���	#FF4C7F8265   �� 5P   
   $	��Do:��6   $��318,45,52,181q�6   ���	#FF4C7F8265   5Q      5R      