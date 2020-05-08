pipeline {
    agent any 
    stages {
        stage('Build') {
            steps {
                echo 'Build Starts!'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" restore \"C:/Projects/MicroBackend/MicroBackend/MicroBackend.sln\""
                bat "\"C:/Program Files/dotnet/dotnet.exe\" build \"C:/Projects/MicroBackend/MicroBackend/MicroBackend.sln\""
                echo 'Build Ends'
            }
        }
	    
	stage('Test') {
            steps {
                echo 'Test Starts!'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" test \"C:/Projects/MicroBackend/MicroBackend/MicroBackend.Auth.Jwt.Test\""
                echo 'Test Ends'
            }
        }
		
	stage('Identity Deploy') {
            steps {
                echo 'Deploy Starts!'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" publish \"C:/Projects/MicroBackend/MicroBackend/MicroBackend.Auth.Api\" --output \"C:/WebApis/IdentityServer\""
                echo 'Deploy Ends'
            }
        }		
        
        stage('Gateway Deploy') {
            steps {
                echo 'Deploy Starts!'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" publish \"C:/Projects/MicroBackend/MicroBackend/MicroBackend.Gateway.Api\" --output \"C:/WebApis/ApiGateway\""
                echo 'Deploy Ends'
            }
        }	

    }
}
