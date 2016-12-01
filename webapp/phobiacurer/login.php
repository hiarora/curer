<?php
include("ws_common.php");
$wsc= new ws_common();
error_reporting(0);
if(isset($_GET['uname']))	$uname = trim($_GET['uname']);
else							$uname = "";
if(isset($_GET['token']))	$token = trim($_GET['token']);
else							$token = "";

if($wsc->IsValidToken($token) !== "True" || $wsc->IsValidUsername($uname) !== "True") {
	echo "Invalid user data";
	return;
}
echo $wsc->AssociateUserAndToken($token, $uname);
 
?>
