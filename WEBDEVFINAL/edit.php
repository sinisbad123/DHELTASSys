<?php
session_start();
include_once 'inc/functions.php';
$user = new User();
$uid = $_SESSION['uid'];
if ($_SERVER["REQUEST_METHOD"] == "POST")
{
    $edit = $user->update_article($_POST['title'], $uid, $_POST['category'], $_POST['article'], $_POST['articletitle']);
    if ($edit) 
    {
        // Registration Success
        header("location:ars.php");
    } 
    else 
    {
        // Registration Failed
        header("location:error103.php");
    }
}
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>WEBDEVT FINAL PROJECT</title>
<link href="main.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="jayc_container_wrapper">
<div id="jayc_container">
	<div id="jayc_banner">
  <div id="site_title">
            <h1><a href="#"></span></a><a href="#"><img src="images/jayc.png" width="176" height="58" /></a></h1>
      </div>
        
        <div id="jayc_menu">
            <ul>
                <li><a href="create.php">Create Article</a></li>
                <li><a href="edit.php" class="current">Edit Article</a></li>
                <li><a href="view.php">View Articles</a></li>
                <li><a href="logout.php">Log-Out</a></li>
            </ul>
		</div> <!-- end of menu -->
    
    </div> <!-- end of banner -->
    
    <div id="jayc_content">
    	
        <div id="side_column">
        
        </div> <!-- end of side column -->
        
        <div id="main_column">
        
            <div class="main_column_section">       
            
                <h2>Edit Your Previous Articles!</h2>
                
                <div class="main_column_section_content">
                
                    <div>
                    <p>
                        <form action="" method="post" name="asd">
                        <table style="width:51%;">
                            <tr>
                                <td class="style1">
                                    </td>
                                <td>
                                    Article Title to be Edited:
                                    <select name="articletitle">
                                    <?php $user->view_article_title($uid); ?>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    Title:</td>
                                <td>
                      <input type="text" name="title" required /></td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    Category:</td>
                                <td>
                      <input type="text" name="category" required /></td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    Article:</td>
                                <td>
                      <textarea rows="4" cols="50" name="article" required></textarea></td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;</td>
                                <td class="style3">
                                    <br />
                        <input type="submit" name="edit" value="Edit"/></td>
                            </tr>
                        </table>
                    </form>
                        </p>
                  </div>
                  </div>
                <div class="bottom"></div>
            </div>
            <div class="cleaner"></div>
    </div> <!-- end of content -->
    
    <div id="jayc_footer">
    
    <div id="jayc_footer_bar">
    
        <ul class="footer_menu">
            <li><a href="create.php">Create Article</a></li>
            <li><a href="edit.php">Edit Article</a></li>
            <li><a href="view.php">View Article</a></li>
        </ul>

        Copyright © 2013 <a href="#">MIKE</a></div>
    
    </div> <!-- end of footer -->

</div> <!-- end of container -->
</div> <!-- end of container wrapper -->
</body>
</html>
