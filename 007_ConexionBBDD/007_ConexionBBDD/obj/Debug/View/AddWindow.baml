   M S B A M L   `   `   `  ����K  G007_ConexionBBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:_007_ConexionBBDD.View_007_ConexionBBDD.View  5   	   &     _007_ConexionBBDD.View.AddWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:_007_ConexionBBDD.View     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialdesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	AddWindow��5	   	   $	��450��6   $	��300��6(    � 
ResizeMode$ NoResize=�64    � WindowStyle$
 None=�6J   .��5
      �� .+�5   
   � $��0,20,0,0q�6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� -   5        $��txbID��5      $��1��6#   $
��12,8q�63   $	��100��6A   $
��Left=�6P   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Introduzca el ID��6k    �� AcceptsReturn .  %  !MaterialDesignFloatingHintTextBox#��[  5   y    �� TextWrapping$
 Wrap=�5      {�5      ��  �� Path$ 	IsChecked�	 �� ElementName$6	 0MaterialDesignTextFieldBoxTextBoxEnabledComboBox��5      �� 5"      -   5        $��	txbNombre��5"      $��1��6'   $��1��64   $
��12,8q�6D   $	��100��6R   $
��Left=�6a   $ Introduzca el nombre��6|    . #��[  5#   y   $
 Wrap=�5$      {�5#      �� $ 	IsChecked�$6	 0MaterialDesignTextFieldBoxTextBoxEnabledComboBox��5$      �� 5(      -   5        $��txbApellidos��5(      $��2��6*   $��1��68   $
��12,8q�6H   $	��150��6V   $
��Left=�6e   $ Introduzca los apellidos��6�    . #��[  5)   y   $
 Wrap=�5*      {�5)      �� $ 	IsChecked�$6	 0MaterialDesignTextFieldBoxTextBoxEnabledComboBox��5*      �� 5.      -   5        $��txbCurso��5.      $��3��6&   $��1��64   $��
12,10,0,10q�6D   $	��100��6X   $
��Left=�6g   $ Introduzca el curso��6�    . #��[  5/   y   $
 Wrap=�50      {�5/      �� $ 	IsChecked�$6	 0MaterialDesignTextFieldBoxTextBoxEnabledComboBox��50      �� 52      $��Sexo:��6   $��4��6%   $
��12,8q�62   $��Center=�6@   $��Right=�6[    % !MaterialDesignSubheadingTextBlock#��[ 6w   �� 54      
 �� Orientation$
 Vertical=�6   $��4��60   $��1��6=   .+�55      	� -   5        $��	rdbHombre��55      $��Hombre��6/   $��Center=�6@     MaterialDesignRadioButton#��[ 6[   	� 56      -   5        $��rdbMujer��56      $��Mujer��6.   $��Center=�6>   #��[ 6Y   57      �� 5;      -   5        $��txbNotaExamen��5;      $��5��6+   $��1��69   $
��12,8q�6I   $��50��6W   $
��Left=�6e   $ Introduzca la nota��6�    . #��[  5<   y   $
 Wrap=�5=      {�5<      �� $ 	IsChecked�$6	 0MaterialDesignTextFieldBoxTextBoxEnabledComboBox��5=      5?      �� 5B   
   -   5         ��Name$ btnInsertar��5B      $��Insertar��6@   $��60, 20, 60, 0q�6S    $  MaterialDesignRaisedAccentButton#��[ 6j    � ToolTip$ Insertar Alumno��6�   �� 5C   
   -	   5        $ 	btnCancel��5C      $��Cancelar��6<   $��60, 20, 60, 0q�6O   #��[ 6f   $ Salir de la aplicación��6�   5E      5F      