   M S B A M L   `   `   `  ����H  DHealthcareMD_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HealthcareMD_HealthcareMD_  5   	   A%clr-namespace:HealthcareMD_.ViewModelHealthcareMD_.ViewModel  63   -clr-namespace:HealthcareMD_HealthcareMD_  6k   .    (HealthcareMD_.DoctorWindows.ReportWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hi:http://schemas.microsoft.com/expression/2010/interactivity     5   	   -localclr-namespace:HealthcareMD_     5   	   ;	viewmodel%clr-namespace:HealthcareMD_.ViewModel     63   5HealthcareMD_clr-namespace:HealthcareMD_     6k     � Title$  	Izveštaj��5
   	   $	��433��6   $	��491��6'   $��14(�63   $��	Yu Gothic)�6A    J� InputBindings 5      �� 5   
    �� 	Modifiers$ Controlf�5      
 �� Key$ X��5       �� Command 5      �� *CloseCommand+�� 5   
   $ Controlf�5      $ S��5       5      �� *AcceptCommand+ � 	Resources 5         validationTemplate � RowDefinitions � ColumnDefinitions ��Name��%M  &	        �� 5   
   .R�5      � $
��Auto��6   $
��Auto��6!    5      �� 5       5      �� 5      �� 5      $
��Auto �6'   .+�5       �� $ textBox��6I   $��0��6,   $��0��6<   6I   �� 5!      $��1��6   $��0��6,   
���  ����69   �� *[0].ErrorContent+6[   5"      5#      5%      .��5&      � ���	#FFCBF4E7 5'   
   �� 5(      $	��11* �6   �� 5)      $
��480* �6   .+�5-   
   �� ���	#FF4C7F82$��4q�6)   	 �� CornerRadius$	 8,8,8,8��6=   $��10,5,10,333q�6T   ���	#FF99E1D9$��2��6�   � 5/   
   $��2��6   .+�50      �� -   5        
 ��Name$
 date_tb��50      $��94,27,234,348q�6'    =� ErrorTemplate# [  6>   ���	#FF345F61.��6�   .��51      ��  �� Path$
 Date�6    �� UpdateSourceTrigger$ 	LostFocus=�6&    �� ValidationRules 52      "   HealthcareMD_.DateValidation  53      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�67   +   %HealthcareMD_.RequiredFieldValidation  54      $ RawProposedValue=�6@   56      57      �� 58      $��Datum:��6   $
��Left=�6%   $��	32,24,0,0q�6@   $	��Top=�6S    J� RenderTransformOrigin$ 1.046,0.543&�6k   ���	#FF345F616�   �� 59      $��
Dijagnoza:��6   $
��Left=�6)   $��
279,22,0,0q�6D   $	��Top=�6X   ���	#FF345F616p   �� 5:      -   5        $
 diagnosis_tb��5:      # [  6,   $
��Left=�6k   $��
357,26,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��86��6�   $��28��6�   ���	#FF345F61.��6�   .��5;      �� $ 	Diagnosis�6   $ 	LostFocus=�6+    5<        5=      $ RawProposedValue=�68   "   HealthcareMD_.CodeValidation  5>      $ RawProposedValue=�6/   5@      5A      �� 5B      ���	#FF4C7F82���	#FF4C7F82$��3q�6D   $	 8,8,0,0��6X   $��10,74,371,208q�6o   �� 5C      ���	#FF4C7F82���	#FF4C7F82$��3q�6D   $	 8,8,0,0��6X   $��243,74,102,199q�6o   5G      �� 5H   
   ���	#FF4C7F82$��4q�6)   $	 0,8,8,8��6=   $��10,110,245,93q�6T   ���	#FF99E1D9$��2��6�   ._�5I      �� -   5        $
 reportString_tb��5I      # [  6/   $��Center=�6o   $
 Wrap=�6�   $��Center=�6�   $	��196��6�   
�������$	��171��6�   ���	#FF345F61.��6�   .��5J      �� $ ReportString�6   $ 	LostFocus=�6.    5K        5L      $ RawProposedValue=�68   5N      5O      5P      �� 5Q   
   $��	Izveštaj��6   $
��Left=�6#   $��7,77,0,0q�6>   $	��Top=�6P   $��18(�6h   $��1��6v   
�������6�   �� 5R   
   $��Anamneza��6   $
��Left=�6#   $��
249,77,0,0q�6>   $	��Top=�6R   $��18(�6j   $��1��6x   
�������6�   �� 5S   
   ���	#FF4C7F82$��4q�6)   $	 0,8,8,8��6=   $��232,110,10,93q�6T   ���	#FF99E1D9$��1��6�   ._�5T      �� -   5        $
 anamnesis_tb��5T      # [  6,   $��Center=�6l   $
 Wrap=�6�   $��Center=�6�   $	��192��6�   
�������$	��174��6�   ���	#FF345F61.��6�   .��5U      �� $ 	Anamnesis�6   $ 	LostFocus=�6+    5V        5W      $ RawProposedValue=�68   5Y      5Z      5[      �� 5]   
   ���	#FF4C7F82���#70ABAF$��3q�6>   $	 8��6R   $��136,314,262,10q�6c   $��1��6{   ._�5_      �� -   5         ��Name$ Schedule��5_      $��-13,-13,-13,-29q�6'   ��6[   Z� ��6r   Z� .��5`      �� $��73��6   $��75��6)   .+�5a      �� $ ��/Resources/acceptWhite.png��6   $��Uniform=�6@   $��36��6R   $��33��6^   �� 5b      $��Prihvati [S]��6   $��Center=�63   
�������$��43��6j   $��76��6v   $��12(�6�   5d      5e      5g      �� 5h   
   ���	#FF4C7F82���#70ABAF$��3q�6>   $	 8��6R   $��249,314,147,10q�6c   $��1��6{   ._�5i      �� -   5        ��5i   0   Z� ��6G   Z� .��5j      �� $��59��6   $��88��6)   $��Center=�64   .+�5k      �� $ ��/Resources/cancelWhite.png��6   $��Uniform=�6@   $��37��6R   $��38��6^   �� 5l      $��Otkaži [X]��6   $��Center=�61   
�������$��12(�6h   5m      5n      5o      5p      5q      