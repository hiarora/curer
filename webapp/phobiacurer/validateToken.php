<?php
include("ws_common.php");
$wsc= new ws_common();
error_reporting(0);
if(isset($_GET['token']))	$token = trim($_GET['token']);
else							$token = "";

if($wsc->ValidateTokenFromUserTable($token) === "True") {
	echo "Valid";
}
else {
	echo "Invalid";
}
?>
