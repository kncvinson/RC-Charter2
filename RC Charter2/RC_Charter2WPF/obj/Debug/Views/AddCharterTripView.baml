   M S B A M L   `   `   `  ����I  ERC_Charter2WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:RC_Charter2WPF.ViewsRC_Charter2WPF.Views  5      G(clr-namespace:RC_Charter2WPF.Views.PartsRC_Charter2WPF.Views.Parts  5      -    'RC_Charter2WPF.Views.AddCharterTripView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:RC_Charter2WPF.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      :parts(clr-namespace:RC_Charter2WPF.Views.Parts     5      .��5      � .+�5      �   � RowDefinitions  5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5      � $��0��6
   .+�5      �� $��	10,0,10,0q�5      
���   �$��0,0,0,1q�5      ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��4,4,0,4q�5       �� Padding$ 4,4,0,4q�5      $��30(�5      $��Add Charter Trip for ��5      �� 5       $��0,4,4,4q�5!      $ 0,4,4,4q�5"      $��30(�5$       � DataContext 5#      ��  �� Path$ SelectedCustomer���5%      �� $
 Name�5&      5'      5(      � 5)      $��1��6
    � ColumnDefinitions 5*      �� 5+      $
��Auto �6   �� 5,      $	��250��6     5.      �� 5/      $
��Auto �6   .+�51      �� $��0��52      $��0��53      $��4q�54      $ 4q�55      $
��Left=�56      $��Center=�57      $��Purpose:��58      �� 59      -   5         ��Name$ 
CbxPurpose��5:      $��0��5;      $��1��5<      $��4q�5=      $��4q�5>       �� 
IsEditable .  �� IsTextSearchEnabled . ��5A      �� $ PurposeList�	 �� SelectedItem	 5B      �� $ SelectedPurpose�5C      � 5D      $��2��6
   .+�5E      �� $ 
Horizontal=�6   .+�5F      �� $��4,4,0,4q�5G      $ 4,4,0,4q�5H      $��Selected Aircraft: ��5I      �� 5J      $��0,4,0,4q�5K      $ 0,4,0,4q�5L      $
��Bold"�5N       5M      �� $ SelectedAircraft���5O      �� $ AircraftNumber��� 5P      $��0,4,0,4q�5Q      $ 0,4,0,4q�5R      $�� ��5S      �� 5T      $��0,4,4,4q�5U      $ 0,4,4,4q�5V      $
��Bold"�5X       5W      �� $ SelectedAircraft���5Y      �� $ Model�5Z      5[      � 5\      $��3��6
    5]      �� 5^      �� 5_      $��5 �6   �� 5`      .+�5b      -   'RC_Charter2WPF.Views.Parts.AircraftList  $��0��6   �� 5c      $��1��5d      $��5��5e      $��Stretch=�5f      
�����w�5g      0   *RC_Charter2WPF.Views.Parts.AircraftDetails  5h      -   5        
  Name$
 AircraftDetails��5h      $��2��65   5i      � 5j      $��4��6
    5k      �� 5l      �� 5m      .+�5o      �� -   5         ��Name$ 	BtnCancel��5p      $��0��5q      $��4q�5r      $��4q�5s      $��Cancel��5u      ��5t      �� $ OpenCustomerViewCommand�5u      �� 5v      $��1��5w      $��4q�5x      $��4q�5y      $ ��Proceed To Crew Assignment��5{      ��5z      �� $$ OpenAddCharterTripView2Command�5{      5|      5}      5~      5      