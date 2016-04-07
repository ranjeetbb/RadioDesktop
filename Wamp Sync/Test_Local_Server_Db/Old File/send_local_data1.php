<?php
    header("refresh:5;");
?>
<?php
//Access Control Headers
header('Access-Control-Allow-Origin: *');
header('Access-Control-Allow-Credentials: true');
header('Access-Control-Allow-Headers: Content-Type');

//Include Files
include 'jsonFormat.php';
include 'jsonDeliver.php';
include 'config.php';
// sending data to server from csvfile table 
$jsonresponse=[];
$data=[];
$sel_doct_mobile=mysql_query("select pt_transaction,radioPatientsId,status from csvfile");
//$sel_doct_mobile=mysql_query("select radioPhoneMobile,alternateMobile1,alternateMobile2 from doctors where radioDoctorId='71'");
$numRows=mysql_num_rows($sel_doct_mobile);
if($numRows>0)
{
	while($row=mysql_fetch_array($sel_doct_mobile))
	{
		$response['transID']=$row['pt_transaction'];
		$response['ptId']=$row['radioPatientsId'];
		$response['stats']=$row['status'];				
		array_push($data,$response);
		
	}
	json_encode($data);
	deliver_response(200,"New Location created","transaction",$data);			
}
?>