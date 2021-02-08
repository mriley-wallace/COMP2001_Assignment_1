<!DOCTYPE html>
<html lang="en">
<head>
    <title>Michael's Dataset</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        /* Remove the navigation bar's default margin-bottom and rounded borders */
        .navbar {
            margin-bottom: 0;
            border-radius: 0;
        }

        /* Set height of the grid so .sidenav can be 100% (adjust as needed) */
        .row.content {
            height: 450px
        }

        /* Set purple background color and 100% height */
        .sidenav {
            padding-top: 20px;
            background-color: #BB8FCE;
            height: 100%;
        }

        /* Set black background color, white text and some padding */
        footer {
            background-color: #555;
            color: white;
            padding: 15px;
        }

        /* On small screens, set height to 'auto' for sidenav and grid */
        @media screen and (max-width: 767px) {
            .sidenav {
                height: auto;
                padding: 15px;
            }

            .row.content {
                height: auto;
            }
        }

        h1 {
            text-align: center;
        }

        h3 {
            text-align: center;
        }

        p {
            text-align: center;
        }

        div {
            text-align: center;
        }

        .center {
            margin: auto;
        }

    </style>
</head>

<body style="background-color:#DAD3EF;">

<nav class="navbar navbar-inverse">
    <div class="container-fluid">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="#">UoP</a>
        </div>
        <div class="collapse navbar-collapse" id="myNavbar">
            <ul class="nav navbar-nav">
                <li><a href="index.php">Home</a></li>
                <li class="active"><a href="data.php">Data</a></li>
                <li><a href="vision.php">Project Vision</a></li>
            </ul>

            <!--Future Scope for logging in-->
            <!--<ul class="nav navbar-nav navbar-right">
                <li><a href="#"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>
            </ul>-->
        </div>
    </div>
</nav>

<div class="container-fluid text-center">
    <div class="row content">
        <div class="col-sm-2 sidenav">
            <p><a href="https://plymouth.thedata.place/dataset/qualifications-and-students-plymouth/resource/f247a04e-2171-4d0b-a50b-77f633b899b4">Original Data Set 1</a></p>
            <p><a href="../entity/index.php">RDF Format</a></p>
<!--            <p><a href="#">Link</a></p>-->
        </div>
        <div class="col-sm-8 text-left">

            <h1> Readable Data Set</h1>
            <p>Below will be a human readable data set for Qualifications.</p>


            <?php
            echo "<html><body><table border='1' class='center'>\n\n";
            $f = fopen("UniResults.csv", "r");
            while (($line = fgetcsv($f)) !== false) {
                echo "<tr>";
                foreach ($line as $cell) {
                    echo "<td>" . htmlspecialchars($cell) . "</td>";
                }
                echo "</tr>\n";
            }
            fclose($f);
            echo "\n</table></body></html>";
            ?>

            <hr>
            <h3>Introduction</h3>
            <p>Michael Riley-Wallace born 28/05/90</p>
            <p>Currently Studying: Bsc(Hons) Computing & Games Development</p>
        </div>
        <div class="col-sm-2 sidenav">
            <div class="well">
                <p>
                    <a href="https://www.youtube.com/watch?v=bl5TUw7sUBs">
                        <img src="../assets/img/startrek1.jpg" alt="ad1" class="center" width="200" height="100">
                    </a>
                </p>
            </div>
            <div class="well">
                <p>
                    <a href="https://www.youtube.com/watch?v=bl5TUw7sUBs">
                        <img src="../assets/img/startrek2.jpg" alt="ad2" class="center" width="200" height="100">
                    </a>
                </p>
            </div>
        </div>
    </div>
</div>

<footer class="container-fluid text-center">
    <p>Website built by Michael Riley-Wallace 2021 on behalf of Plymouth University</p>
</footer>

</body>
</html>








