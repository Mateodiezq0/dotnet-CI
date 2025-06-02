FROM jenkins/jenkins:lts

USER root

RUN apt-get update && apt-get install -y curl gnupg2 ca-certificates lsb-release \
    && curl -fsSL https://deb.nodesource.com/setup_18.x | bash - \
    && apt-get install -y nodejs \
    && npm install -g vercel \
    && apt-get clean

USER jenkins
