$url = "http://localhost:5002/api/User/search"

$term = Read-Host "Enter FirstName or LastName of user " 
$searchUrl = "$($url)?searchTerm=$($term)" 


try {
    Write-Output $searchUrl
    $response = Invoke-RestMethod -Method GET -Uri $searchUrl -ContentType "application/json"
    Start-Sleep -Milliseconds 1000
    Write-Host "Response: " 
    Write-Output $response
}
catch {
    Write-Host $_.Exception.Message
}