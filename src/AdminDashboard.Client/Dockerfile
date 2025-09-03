FROM node:22-alpine
WORKDIR /app

COPY 'AdminDashboard.Client/package*.json' .
RUN npm install

COPY 'AdminDashboard.Client/' .
EXPOSE 3000

ENTRYPOINT ["npm", "run", "dev"]