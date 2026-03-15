pipeline {
    agent any
    stages {

        stage('Checkout') {
            steps {
                git branch: 'main',
                url: 'https://github.com/NuwanChaminda/playwright-reqnroll-framework.git'
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