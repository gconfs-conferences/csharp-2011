#! /usr/bin/env make

SHELL = /bin/bash

full: conf-BDSP-tp conf-BDSP-conf

conf-BDSP-tp:
	@(cd ./tp/CAS/sujet && $(MAKE))
	@(cd ./tp/TP\_Simple && $(MAKE))

conf-BDSP-conf:

clean:
	@(cd ./tp/CAS/sujet && $(MAKE) $@)
	@(cd ./tp/TP\_Simple && $(MAKE) $@)

#END
