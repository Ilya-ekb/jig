#!/bin/bash
git -c http.sslVerify=false submodule update --init --recursive
git -c http.sslVerify=false submodule update --recursive --remote
