<?php 
header("Content-Type: text/html; charset=utf-8"); 
session_start();
if ($_SESSION['send'] == $_SERVER['REMOTE_ADDR'])  
{
	require 'user.php';
	$usr = new user();
	$login = $hpassword = $email = $temp = '';
	$_SESSION['message'] = ''; 
	$flag = true;
	if (!empty($_GET["login"])) {
	$login = strip_tags($_GET["login"]);
	$login = htmlspecialchars($login);}
	else 
	{$flag = false ; $_SESSION['message'] = 'Неверно указан login!'; }
	if (!empty($_GET["password"]))
	{ 	
	$temp = htmlspecialchars($_GET["password"]);
	$temp = strip_tags($temp);
	$hpassword = crypt($temp,'$1$qwe$');
	}
	else 
	{$flag = false ; $_SESSION['message'] = 'Неверно указан password!'; }
	if (filter_var($_GET["email"], FILTER_VALIDATE_EMAIL) && !empty($_GET["email"])) {	
    $email = strip_tags($_GET["email"]); 
	$email = htmlspecialchars($email);}
	else 
	{$flag = false ; $_SESSION['message'] = 'Неверно указан email!'; }
	$conerror = $usr->ConnectToDB();
	
	
	if($flag == true)
	{
	$res = $usr->Insrt($login, $hpassword, $email);
	if ($res)
    $_SESSION['message'] = 'Done'; }
    else {
    $_SESSION['message'] = 'error'; 
	}
	$conerror = $usr->Disconnect();
}
?>