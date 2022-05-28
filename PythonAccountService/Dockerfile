# Reference
FROM python:3.7-alpine3.7

# work dir
WORKDIR /app

# add current file
COPY requirements.txt /app/requirements.txt

# install package
RUN pip install -r requirements.txt

COPY . .

# expose 8888 to outside of the docker container
EXPOSE 80

# run this app server
CMD ["python","main.py"]