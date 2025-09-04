FROM node:22-alpine
WORKDIR /app

COPY 'AdminDashboard.Client/package*.json' .
RUN npm install

COPY 'AdminDashboard.Client/' .
RUN rm .env
RUN mv .env.container .env
EXPOSE 3000

ENTRYPOINT ["npm", "run", "dev"]