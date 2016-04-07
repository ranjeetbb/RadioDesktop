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
// sending data to server from doctors table 
$jsonresponse=[];
$data=[];
$sel_doct_mobile=mysql_query("select radioDoctorId,radioPhoneMobile,alternateMobile1,alternateMobile2 from doctors where alternateMobile1 !='' or alternateMobile2 !=''");
//$sel_doct_mobile=mysql_query("select radioPhoneMobile,alternateMobile1,alternateMobile2 from doctors where radioDoctorId='71'");
$numRows=mysql_num_rows($sel_doct_mobile);
if($numRows>0)
{
	while($row=mysql_fetch_array($sel_doct_mobile))
	{
		$response['Ra_dr_Id']=$row['radioDoctorId'];
		$response['Ra_M']=$row['radioPhoneMobile'];
		$response['Altr_M']=$row['alternateMobile1'];
		$response['Altr_M1']=$row['alternateMobile2'];			
		array_push($data,$response);
		
	}
	json_encode($data);
	deliver_response(200,"New Location created","doctor_mobile",$data);			
}
?>