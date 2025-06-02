pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:7.0'
        }
    }

    stages {
        stage('Build') {
            steps {
                sh 'dotnet build'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish -c Release -o ./out'
            }
        }

        stage('Deploy') {
            steps {
                // Paso opcional dependiendo de tu entorno
                sh 'echo "Desplegando..."'
            }
        }
    }
}
