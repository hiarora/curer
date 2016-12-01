<?php
include("ws_common.php");
$wsc= new ws_common();
error_reporting(0);
if(isset($_GET['uname']))	$uname = trim($_GET['uname']);
else							$uname = "";
if(isset($_GET['level']))	$level = trim($_GET['level']);
else							$level = "";

echo $wsc->GetUserDataForLevel($uname, $level);
 ?>
