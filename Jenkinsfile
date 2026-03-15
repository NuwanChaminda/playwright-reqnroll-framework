pipeline {
    agent any

    tools {
        dotnet 'dotnet8'
    }

    stages {

        stage('Checkout') {
            steps {
                git 'https://your-repo-url.git'
            }
        }

        stage('Clean') {
            steps {
                bat 'dotnet clean'
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --no-restore'
            }
        }

        stage('Run Tests') {
            steps {
                bat 'dotnet test --logger "trx"'
            }
        }

    }

    post {

        always {

            allure([
                includeProperties: false,
                jdk: '',
                results: [[path: 'allure-results']]
            ])

        }

    }
}