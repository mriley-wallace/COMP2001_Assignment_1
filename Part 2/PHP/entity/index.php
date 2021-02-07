<?php
$OpenTheCSV = fopen("../entity/UniResults.csv", "r");

echo '{ "@context" : { "Region" : "http://schema.org", "educationCredentialAwarded" : "http://web.socem.plymouth.ac.uk" }, "total" : [ { "@type" : "Course", </br>';


while (($line = fgetcsv($OpenTheCSV)) !== false) {
    if (!empty($line)) {

        if ($line == $OpenTheCSV) {
            echo($line);
        }
        echo '{ </br>';
        echo '"@type"  :  "Course" </br>';
        echo '"educationalCredentialAwarded"  :  '.$line[0].'</br>';
        echo '"total-type" :  '.$line[1].'</br>';
        echo '"person"  :  '.$line[2].'</br>';
        echo '"date"  :  '.$line[3].'</br>';
        echo '"total"  :  '.$line[5].'</br>';
        echo '}, </br>';
        echo '</br>';

    }
}
fclose($OpenTheCSV);

