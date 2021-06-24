$url = "http://localhost:5002/api/User"

# Modify body to add new user
$body = @{
  firstName = "power"
  lastName = "shell"
  address = "string"
  age= 20
  interests= @("powershell")
}

try {
    $response = Invoke-RestMethod -Method POST -Uri $url -Body ($body|ConvertTo-Json) -ContentType "application/json"
    Start-Sleep -Milliseconds 1000
    Write-Host "User created: "
    Write-Output $response
}
catch {
    Write-Host $_.Exception.Message
}