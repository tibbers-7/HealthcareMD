   M S B A M L   `   `   `  ����H  DHealthcareMD_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:HealthcareMD_.DoctorViewHealthcareMD_.DoctorView  5   	   -clr-namespace:HealthcareMD_HealthcareMD_  5   	   A%clr-namespace:HealthcareMD_.ViewModelHealthcareMD_.ViewModel  6;   -    'HealthcareMD_.DoctorView.ReferralWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hi:http://schemas.microsoft.com/expression/2010/interactivity     5   	   8local&clr-namespace:HealthcareMD_.DoctorView     5   	   5HealthcareMD_clr-namespace:HealthcareMD_     5   	   ;	viewmodel%clr-namespace:HealthcareMD_.ViewModel     6;     � Title$  ReferralWindow��5   	   $	��452��6    $	��402��6-   $��	Yu Gothic)�69    J� InputBindings 5      �� 5   
    �� 	Modifiers$ Controlf�5      
 �� Key$ X��5       �� Command 5      �� *CancelCommand+�� 5   
   $ Controlf�5      $ S��5       5      �� *AcceptCommand+�� 5   
   $ Controlf�5      $ P��5       5      �� *PatientCommand+ � 	Resources 5         validationTemplate � RowDefinitions � ColumnDefinitions ��Name��%M  &	        �� 5   
   .R�5      � $
��Auto��6   $
��Auto��6!    5      �� 5       5!      �� 5"      �� 5#      $
��Auto �6'   .+�5&      �� $ textBox��6I   $��0��6,   $��0��6<   6I   �� 5'      $��1��6   $��0��6,   
���  ����69   �� *[0].ErrorContent+6[   5(      5)      5*      .��5-      � ���	#FFCBF4E7 5.   
   �� 5/      $
��219* �6   �� 50      $
��197* �6   .+�52   
   �� ���	#FF4C7F82$��4q�6)   	 �� CornerRadius$	 8,8,8,8��6=   $��10,44,10,62q�6T   ���	#FF99E1D96i   � 55   
   .+�56      �� $��Kod lekara:��6   $
��Left=�6*   $��
25,108,0,0q�6E   $	��Top=�6Y   $��67��6q   $	��116��6}   ���	#FF345F616�   �� 57      $��
Pacijenta:��6   $
��Left=�6)   $��	25,62,0,0q�6D   $	��Top=�6W   $��67��6o   $	��116��6{   ���	#FF345F616�   �� 58      -   5        
 ��Name$
 patientId_tb��59   	    =� ErrorTemplate# [  58      $
��Left=�59      $��	96,63,0,0q�6:    �� TextWrapping$
 Wrap=�6M   $	��Top=�6a   $	��119��6y   
�������$��23��6�   ���	#FF345F61.��6�   .��5:      ��  �� Path$ 	PatientId�6    �� UpdateSourceTrigger$ PropertyChanged=�6+    �� Mode$ TwoWay=�6R    �� ValidationRules 5;      %   HealthcareMD_.NumericValidation  5<      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�6:   +   %HealthcareMD_.RequiredFieldValidation  5=      $ RawProposedValue=�6@   5?      5@      �� 5A      ���	#FF4C7F82���	#FF70ABAF$��3q�6D   $	 8��6X   $��231,56,19,115q�6i   ._�5B      �� -   5         ��Name$ patientButton��5B      $��Center=�61   $��Center=�6N   $��35��6i   $	��142��6u   $��12(�6�   
���������6�   Z� ��6�   Z� .��5C      ��  �� Orientation$ 
Horizontal=�6!   .+�5D      �� -   5         ��Name$ patientLabel��5D       $��Izaberi Pacijenta [P]��66   
�������$	��112��6i   $��11(�6u   �� 5E      $!��/Resources/patientWhite.png��6    $��Uniform=�6E   $��30��6W   $��27��6c   5F      5G      5H      �� 5I      -   5         ��Name$ doctorSpecialization_cb��5I      $
��Left=�6�   $��96,109,0,80q�6�   $	��119��6�   ���	#FF345F61 �� SelectedItem 68   �� *DoctorSpecialization+��6f   �� *Specializations+6�   5J      �� 5L   
   ���	#FF4C7F82���	#FF4C7F82$��3q�6@   $	 8,8,0,0��6T   $��10,173,273,1q�6k   ._�5M      �� $��	Tip uputa��6   $��18(�6(   $��	0,0,-35,0q�66   
�������6I   5N      �� 5O   
   ���	#FF4C7F82$��4q�6)   $	 0,8,8,8��6=   $��10,203,10,160q�6T   ���	#FF99E1D9$��2��6�   � 5Q   
   $��10,211,-10,96q�6   $��2��6&   .+�5R      	� -   5         	�Name$ 
surgery_rb��5R      $��	Operacija��6L   $
��Left=�6`   $��37,9,0,0q�6{   $	��Top=�6�   $��18(�6�   ���	#FF345F61 d� 	IsChecked 6.   �� *	Surgery+6�   	� 5S      -   5        $ appt_tb��5S      $��Pregled��6F   $
��Left=�6X   $��	234,9,0,0q�6s   $	��Top=�6�   $��18(�6�   ���	#FF345F61 6+   �� *Appt+6�   5T      �� 5V   
   -   5         ��Name$ emergency_cb��5V   3   $��Hitno��6I   $
��Left=�6Y   $��
166,67,0,0q�6t   $	��Top=�6�   $��31��6�   $��90��6�   $��20(�6�    J� RenderTransformOrigin$ 	0.429,4.4&�6�   $��1��6�   ���	#FF345F61 6   �� *	Emergency+6�   �� 5W   
   $��	upućuje:��6   $
��Left=�6#   $��	298,4,0,0q�6>   $	��Top=�6Q   ���	#FF345F616i   �� 5X   
   $
��Left=�6   $��10,8,0,0q�6-   $
 Wrap=�6?   $��Center=�6S    �� 
IsReadOnly$
 True��6w   $	��Top=�6�   $	��288��6�   
����������	#FF345F61��6�   �� *CurrentDoctor+6�   �� 5Y   
   ���	#FF4C7F82���#70ABAF$��3q�6>   $	 8��6R   $��112,103,209,10q�6c   $��1��6{   ._�5[      �� -   5        $ Schedule��5[      $��-13,-13,-13,-29q�6'   ��6]   Z� ��6t   Z� .��5\      �� $��83��6   $��75��6)   .+�5]      �� $ ��/Resources/acceptWhite.png��6   $��Uniform=�6@   $��36��6R   $��33��6^   �� 5^      $��Prihvati [S]��6   $��Center=�63   
�������$��43��6j   $��76��6v   5`      5a      5c      �� 5d   
   ���	#FF4C7F82���#70ABAF$��3q�6>   $	 8��6R   $��231,103,87,10q�6c   $��1��6z   ._�5e      �� -	   5        ��5e   0   Z� ��6G   Z� .��5f      �� $��69��6   $��89��6)   $��Center=�64   .+�5g      �� $ ��/Resources/cancelWhite.png��6   $��Uniform=�6@   $��37��6R   $��38��6^   �� 5h      $��Otkaži [X]��6   $��Center=�61   
�������6U   5i      5j      5k      5l      5m      