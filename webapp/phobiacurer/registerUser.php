<?php
include("ws_common.php");
$wsc= new ws_common();
error_reporting(0);
if(isset($_GET['uname']))	$uname = trim($_GET['uname']);
else							$uname = "";



if($wsc->IsValidUsername($uname) === "True") {
	echo "Username already exists";
	return;
}
$wsc->CreateUser($uname);
 
?>
