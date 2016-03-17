#! /usr/bin/env make
SHELL = /bin/bash

TARBALL = sujet.tgz # FIXME
SUPPORT_INPUT = \
	sujet.tex

full:
	$(MAKE) sujet.pdf && $(MAKE) sujet.pdf
sujet.pdf: $(SUPPORT_INPUT)
	pdflatex sujet.tex

clean:
	rm -f *.{aux,log,nav,out,snm,toc}
distclean: clean
	rm -f sujet.pdf
dist: distclean
	hg archive -t tgz $(TARBALL)

.PHONY: sujet.pdf
