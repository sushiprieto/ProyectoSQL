   M S B A M L   `   `   `  ����K  G007_ConexionBBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:_007_ConexionBBDD_007_ConexionBBDD  5   	   "    _007_ConexionBBDD.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:_007_ConexionBBDD     5   	     � Title$  
MainWindow��5   	   $	��500��6   $
��1000��6)   .��5
      ��  �� Orientation$ Vertical=�6   .+�5   
   �� $ 
Horizontal=�6   $��
10,30,10,0q�6.   .+�5      �� -   5         ��Name$ btnLoadDataGrid��5      $��Mostrar��6L   $
��Left=�6^   $	��Top=�6y    $   MaterialDesignRaisedAccentButton#��[  6�    � ToolTip$ Mostrar Alumnos��6�   �� 5      -   5        $ btnAdd��5      $��Añadir��6:   $
��Left=�6K   $	��Top=�6f   $��50,0,0,0q�6~   #��[  6�   $ Añadir un alumno��6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridCustomers��5         AutoGenerateColumns .  $��Center=�6o   $��0,30,0,0q�6�      CanUserResizeRows .     CanUserResizeColumns .  ��6.   �� *CargarAlumno+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      	   
Foreground	 �#FF4081,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6\      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   ��  �� Path$ AlumnoID�6h     5      	 �#FF4081$
 Nombre��6Z   $	 100 6j    6:   �� $ Nombre�6j     5      	 �#FF4081$
 	Apellidos��6]   $	 100 6p    6:   �� $ 	Apellidos�6p     5      	 �#FF4081$
 Curso��6Y   $ 80 6h    6:   �� $ Curso�6h     5      	 �#FF4081$

 Sexo��6X   $ 55 6f    6:   �� $
 Sexo�6f     5      	 �#FF4081$
 
Nota Exmen��6^   $ 90 6r    6:   �� $ 
NotaExamen�6r   4  .System.Windows.Controls.DataGridTemplateColumn  5       $
 EDITAR��6)      CellTemplate 5!      �� 5"      .R�5#      �� $ btnEditarFila��6%   -   5        $��Editar��5#   <   6M   5$      5&        5(      $
 BORRAR��6)    5)      �� 5*      .R�5+      �� $ btnBorrarFila��6%   -   5        $��Borrar��5+   <   6M   5,      5.      51      53      54      