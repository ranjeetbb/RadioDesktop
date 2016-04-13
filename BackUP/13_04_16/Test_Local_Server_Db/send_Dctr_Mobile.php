<?php
//header("refresh:5;");
include 'config.php';
// sending data to server from doctors table 
$doctor_Mobile=array();
$sel_doct_mobile=mysql_query("select radioDoctorId,radioPhoneMobile,alternateMobile1,alternateMobile2 from doctors where alternateMobile1 !='' or alternateMobile2 !=''");
$numRows=mysql_num_rows($sel_doct_mobile);
if($numRows>0)
{
	while($row=mysql_fetch_assoc($sel_doct_mobile))
	{
		$doctor_Mobile[]=$row;
	}		
}
echo json_encode($doctor_Mobile);
?>