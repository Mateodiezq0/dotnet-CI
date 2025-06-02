pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = 1
        DEPLOY_SCRIPT = './deploy-local.sh'
    }

    stages {
        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build --no-restore'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test --no-build --verbosity normal'
            }
        }
        stage('Publish') {
            steps {
                sh 'dotnet publish -c Release -o out'
            }
        }
        stage('Deploy') {
            when {
                branch 'main'
            }
            steps {
                sh 'chmod +x ${DEPLOY_SCRIPT} && ${DEPLOY_SCRIPT}'
            }
        }
    }
}
