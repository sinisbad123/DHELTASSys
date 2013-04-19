<?php
session_start();
include_once 'inc/functions.php';
$user = new User();
$uid = $_SESSION['uid'];
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
                <li><a href="edit.php">Edit Article</a></li>
                <li><a href="view.php" class="current">View Articles</a></li>
                <li><a href="logout.php">Log-Out</a></li>
            </ul>
		</div> <!-- end of menu -->
    
    </div> <!-- end of banner -->
    
    <div id="jayc_content">
    	
        
        <div id="side_column">
        
            <div class="side_column_box">
            
                <h2>Welcome</h2>
                
                <div class="side_column_box_content">
                    <div class="news_section">
                     <h3>The Article Page. To Comment / View Comments just click on the Article Titles. to find you interest just find in the category below which specific articles you want to sort.</h3>
                     <br>
                     <center>
                     <strong>Categories:<br></strong>
                     <?php $user->view_category();?>
                    </center>
                  </div>
                </div>
            </div>
        </div> <!-- end of side column -->
        
        <div id="main_column">
        
            <div class="main_column_section">       
            
                <h2>View Articles!</h2>
                
                <div class="main_column_section_content">
                        <?php 
                            $user->view_article();
                        ?>
                  <div> 
                    <p></p>
                  </div>
                  </div>
              <div class="cleaner"></div>
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