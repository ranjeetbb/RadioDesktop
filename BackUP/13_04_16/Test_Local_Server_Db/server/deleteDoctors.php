<?php
header('Access-Control-Allow-Origin: *');
include 'config.php';

$drId = array();
$drId =json_decode(@$_POST['doctorID']);

	//$updateQuery="UPDATE doctormobilenumber SET flag=2 where doctorId='$cars'";
	//$updateRun=mysql_query($updateQuery,$conn);
$arrlength = count($drId);
for($x =0; $x <$arrlength; $x++)
{  	
	$updateQuery="delete from doctormobilenumber where doctorId='$drId[$x]'";
	$res=mysql_query($updateQuery,$conn);
}
?>