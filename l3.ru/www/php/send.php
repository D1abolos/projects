<?php 
header("Content-Type: text/html; charset=utf-8"); 
session_start();
if ($_SESSION['send'] == $_SERVER['REMOTE_ADDR'])  
{
$login = $password = $email = $temp = '';
$_SESSION['message'] = ''; 
$flag = true;
if (!empty($_GET["login"])) 
	$login = $_GET["login"];
else {$flag = false ; $_SESSION['message'] = 'Неверно указан login!'; }
if (!empty($_GET["password"]))
	{ 	
	$temp = $_GET["password"];
	$password = crypt($temp,'$1$qwe$');
	}
else {$flag = false ; $_SESSION['message'] = 'Неверно указан password!'; }
if (filter_var($_GET["email"], FILTER_VALIDATE_EMAIL) && !empty($_GET["email"])) 
    $email = $_GET["email"]; 
else {$flag = false ; $_SESSION['message'] = 'Неверно указан email!'; }
if($flag == true)
{
$_SESSION['message'] = 'Done'; 
$f = fopen('file.txt', 'a'); 
fwrite($f, $login." \n");
fwrite($f, $password." \n"); 
fwrite($f, $email." \r\n"); 
fclose($f); 
}
}
else {$_SESSION['message'] = 'Error';}
$back = $_SERVER['HTTP_REFERER']; 
echo "
<html>
  <head>
   <meta http-equiv='Refresh' content='0; URL=".$_SERVER['HTTP_REFERER']."'>
  </head>
</html>";
?>