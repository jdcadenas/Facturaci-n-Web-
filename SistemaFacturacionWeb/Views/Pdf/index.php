<?php
$supervisor=$_REQUEST['supervisor'];
$fecha=$_REQUEST['fecha'];
$fecha1=$_REQUEST['fecha'].' 00:00:00';
$fecha2=$_REQUEST['fecha'].' 23:00:00';
include 'plantilla2.php';

$pdf= new PDF();
$pdf->AliasNbPages();
$pdf->AddPage();
$pdf->SetFillColor(230,230,230);
$pdf->SetFont('Arial', '', '12');


}
$pdf->MultiCell(180,6, 'Novedades:________________________________________________________________________________________________________________________________________________________________________________________________________________________',0,0,'c',0);
$pdf->Output('D','asistencia.pdf');

?>

