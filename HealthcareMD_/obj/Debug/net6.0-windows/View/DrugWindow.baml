   M S B A M L   `   `   `  ����H  DHealthcareMD_, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:HealthcareMD_.DoctorViewHealthcareMD_.DoctorView  5   	   A%clr-namespace:HealthcareMD_.ViewModelHealthcareMD_.ViewModel  6>   )    #HealthcareMD_.DoctorView.DrugWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Hi:http://schemas.microsoft.com/expression/2010/interactivity     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:HealthcareMD_.DoctorView     5   	   ;	viewmodel%clr-namespace:HealthcareMD_.ViewModel     6>     � Title$  
DrugWindow��5	   	   $	��460��6   $	��403��6)   $��	Yu Gothic)�65    J� InputBindings 5
      �� 5   
    �� 	Modifiers$ Controlf�5      
 �� Key$ X��5       �� Command 5      �� *CloseCommand+.��5      � ���	#FFCBF4E7.+�5   
   �� ���	#FF4C7F82���	#FF4C7F82$��3q�6@    �� CornerRadius$ 8,8,0,0��6T   $��217,63,92,300q�6k   ._�5      �� $��Sastojci��6   $��15(�6'   $��0,-5,-40,-23q�65   
�������6K   5      �� 5   
   ���	#FF4C7F82$��4q�6)   $ 0,8,8,8��6=   $��217,94,10,102q�6T   ���	#FF99E1D9._�5      �� $	��143��6:   $��12,17,12,17q�6F   ���	#FF345F61��6   �� *Ingredients+6[   5      �� 5   
   ���	#FF4C7F82$��4q�6)   $ 8,8,8,8��6=   $��12,68,198,10q�6T   ���	#FF99E1D9._�5      � .+�5      �� $
��Left=�6    �� TextWrapping$
 Wrap=�65    �� 
IsReadOnly$
 True��6a   $	��Top=�6s   $	��103��6�   $��27��6�    �� TextAlignment$ Center=�6�   $��57,6,0,0q�6�   ���	#FF345F61��6I   �� *Status+6�   �� 5      $��Status��6   $
��Left=�6)   $��6,6,0,0q�6D   $	��Top=�6U   ���	#FF345F616m   �� 5      $��Tip leka��6   $
��Left=�6+   $��3,44,0,0q�6F   $	��Top=�6X   $��88��6p   $��40��6{   ���	#FF345F616�   �� 5      $��	57,44,6,0q�6   $
 Wrap=�6.   $
 True��6X   $	��Top=�6j   $��28��6�   $ Center=�6�   ���	#FF345F61��6B   �� *Type+6�   �� 5      $��Opis:��6   $
��Left=�6(   $��	64,77,0,0q�6C   $	��Top=�6V   $��88��6n   $��40��6y   ���	#FF345F616�   �� 5       $ Justify=�67   $��10,105,10,19q�6O   "	 �� VerticalScrollBarVisibility$	 Visible=�6e   $
 Wrap=�6�   $
 True��6�   ���	#FF345F61��6   �� *Description+6�   5!      5"      �� 5$   
   $��Center=�6   $��0,10,0,0q�6/   $
 Wrap=�6A   $
 True��6k   $	��Top=�6}   $	��422��6�   $��44��6�   $ Center=�6�   ���	#FF4C7F82
�������$��20(�6  $��SemiBold"�6  ��6U   �� *Name+��6�   Z� 6  �� 5%   
   ���	#FF4C7F82���#70ABAF$��3q�6>   $ 8��6R   $��278,332,38,10q�6c   ._�5&      �� -   5        $��-1,-1,-1,-1q�5&      
���   �
 J� RenderTransformOrigin$
 0.142,0.458&�6p   ��6>   Z� ��6�   Z� .��5'      �� $��70��6   .+�5(      �� $ ��/Resources/cancelWhite.png��6   $��38��6@   $��34��6L   �� 5)      $��Otkaži [X]��6   
�������$��97��6D   $��11(�6O   5*      5+      5,      50      51      