   M S B A M L   `   `   `  ����K  G007_ConexionBBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:_007_ConexionBBDD.View_007_ConexionBBDD.View  5   	   +    %_007_ConexionBBDD.View.RegistroWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:_007_ConexionBBDD.View     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialdesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  RegistroWindow��5	   	   $	��350��6    $	��300��6-    � 
ResizeMode$ NoResize=�69    � WindowStyle$
 None=�6O   .��5
      �� .+�5   
   � $��0,20,0,0q�6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� -   5        $��
txbUsuario��5      $��1��6(   $
��12,8q�68   $	��100��6F   $
��Left=�6U   $��20(�6p   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Introduzca el usuario��6~    �� AcceptsReturn .  %  !MaterialDesignFloatingHintTextBox#��[  5   y    �� TextWrapping$
 Wrap=�5      {�5      ��  �� Path$ 	IsChecked�	 �� ElementName$6	 0MaterialDesignTextFieldBoxTextBoxEnabledComboBox��5      �� 5      -   5        $��txbClave��5      $��1��6&   $��1��63   $
��12,8q�6C   $	��100��6Q   $
��Left=�6`   $��20(�6{   $ Introduzca la contraseña��6�    . #��[  5   y   $
 Wrap=�5      {�5      �� $ 	IsChecked�$6	 0MaterialDesignTextFieldBoxTextBoxEnabledComboBox��5      �� 5!      -   5        $��txbClaveConfirm��5!      $��2��6-   $��1��6:   $
��12,8q�6J   $	��100��6X   $
��Left=�6g   $��20(�6�   $ Confirme la contraseña��6�    . #��[  5"   y   $
 Wrap=�5#      {�5"      �� $ 	IsChecked�$6	 0MaterialDesignTextFieldBoxTextBoxEnabledComboBox��5#      5%      �� 5'   
   -   5        
 ��Name$
 btnRegistrar��5'      $��	Registrar��6B   $��60, 20, 60, 0q�6V    $  MaterialDesignRaisedAccentButton#��[ 6m    � ToolTip$ Registrarse��6�   �� 5(   
   -   5        $
 	btnCancel��5(      $��Cancelar��6<   $��60, 20, 60, 0q�6O   #��[ 6f   $ Salir de la aplicación��6�   5*      5+      